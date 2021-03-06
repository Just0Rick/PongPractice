﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Pong.Escenas;

namespace Pong.Manejadores
{
    public class Pantallas
    {
        protected PongGame contexto;
        protected EscenaBase escenaActual = null;
        protected Dictionary<string, EscenaBase> escenasCargadas;

        public Pantallas(PongGame contexto)
        {
            this.contexto = contexto;
            escenasCargadas = new Dictionary<string, EscenaBase>();
            InicializarComponentes();
        }

        protected void InicializarComponentes()
        {
            if(File.Exists("Config.sav"))
            {
                using (FileStream fichero = new FileStream("Config.sav", FileMode.Open))
                {
                    BinaryFormatter formato = new BinaryFormatter();
                    try
                    {
                        Global.Config.SetValues((Global.Config)formato.Deserialize(fichero));
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error cargando las opciones: " + ex.Message);
                    }
                }
            }
            EscenaBase escenaPorDefecto = new MenuPrincipal(this, new SpriteBatch(contexto.GraphicsDevice), null);
            escenasCargadas.Add(escenaPorDefecto.Nombre, escenaPorDefecto);
            escenaActual = escenaPorDefecto;
        }

        public TRecurso CargarRecurso<TRecurso>(string ruta)
        {
            return contexto.Content.Load<TRecurso>(ruta);
        }

        public bool ComprobarSiLaEscenaExiste(string escena)
        {
            return escenasCargadas.ContainsKey(escena);
        }

        public void CambiarANuevaEscena<TEscena>(bool guardarEscenaActual)
            where TEscena : EscenaBase
        {
            string padre = escenaActual.Nombre;
            if (!guardarEscenaActual)
            {
                escenasCargadas.Remove(escenaActual.Nombre);
                padre = null;
            }

            EscenaBase nuevaEscena = (TEscena)Activator.CreateInstance(typeof(TEscena), this, new SpriteBatch(contexto.GraphicsDevice), padre);
            escenasCargadas.Add(nuevaEscena.Nombre, nuevaEscena);
            escenaActual = nuevaEscena;
        }

        public void CambiarAEscenaCargada(string escena, bool guardarEscenaActual)
        {
            if (!escenasCargadas.ContainsKey(escena))
                return;

            if(!guardarEscenaActual)
                escenasCargadas.Remove(escenaActual.Nombre);

            escenaActual = escenasCargadas[escena];
        }

        public void Update(GameTime gameTime)
        {
            escenaActual?.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            contexto.GraphicsDevice.Clear(Color.Black);

            escenaActual?.Draw(gameTime);
        }
        
        public void ExitGame()
        {
            using (FileStream fichero = new FileStream("Config.sav", FileMode.Create))
            {
                BinaryFormatter formato = new BinaryFormatter();
                try
                {
                    formato.Serialize(fichero, Global.Config.ObtenerObjeto());
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error serializando los datos: " + ex.Message);
                }
            }
            contexto.Exit();
        }
    }
}

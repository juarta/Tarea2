using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarea2.Models;

namespace Tarea2.Controllers
{
    public class CiclistasController : Controller
    {
        // Acción para mostrar la lista de ciclistas
        public ActionResult Index()
        {
            List<Ciclista> ciclistas = Session["Ciclistas"] as List<Ciclista> ?? new List<Ciclista>();
            return View(ciclistas);
        }

        // Acción para mostrar el formulario de registro de un nuevo ciclista
        public ActionResult Agregar()
        {
            return View();
        }

        // Acción para guardar el nuevo ciclista en la variable de sesión
        [HttpPost]
        public ActionResult Agregar(Ciclista ciclista)
        {
            if (ModelState.IsValid)
            {
                List<Ciclista> ciclistas = Session["Ciclistas"] as List<Ciclista> ?? new List<Ciclista>();
                ciclistas.Add(ciclista);
                Session["Ciclistas"] = ciclistas;
                return RedirectToAction("Index");
            }
            return View(ciclista);
        }

        // Acción para capturar el tiempo del ciclista en la variable de sesión
        [HttpGet]
        public ActionResult CapturarTiempo(int id)
        {
            // Obtener el ciclista con el ID proporcionado
            List<Ciclista> ciclistas = Session["Ciclistas"] as List<Ciclista>;
            Ciclista ciclista = ciclistas.FirstOrDefault(c => c.Id == id);

            if (ciclista != null)
            {
                // Pasa el ciclista a la vista de captura de tiempo
                return View(ciclista);
            }

            return RedirectToAction("Index");
        }
        // Acción para guardar el tiempo del ciclista en la variable de sesión
        [HttpPost]
        public ActionResult CapturarTiempo(int id, int minutos, int segundos)
        {
            List<Ciclista> ciclistas = Session["Ciclistas"] as List<Ciclista>;
            Ciclista ciclista = ciclistas.FirstOrDefault(c => c.Id == id);

            if (ciclista != null)
            {
                // Actualizar el tiempo del ciclista con los valores proporcionados
                TimeSpan tiempo = new TimeSpan(0, minutos, segundos);
                ciclista.Tiempo = tiempo;
                Session["Ciclistas"] = ciclistas;

                // Calcular la velocidad nuevamente
                CalcularVelocidad();
            }

            return RedirectToAction("Index");
        }


        // Acción para calcular la velocidad en metros por segundo de cada ciclista
        public ActionResult CalcularVelocidad()
            {
            List<Ciclista> ciclistas = Session["Ciclistas"] as List<Ciclista>;
            if (ciclistas != null)
            {
                foreach (Ciclista ciclista in ciclistas)
                {
                    // Verificar si el tiempo del ciclista está disponible y si la velocidad aún no ha sido calculada
                    if (ciclista.Tiempo != null && ciclista.Velocidad == 0)
                    {
                        // Realizar el cálculo de la velocidad utilizando la fórmula adecuada
                        double metrosPorSegundo = 12000.0 / ciclista.Tiempo.TotalSeconds;
                        if (double.IsInfinity(metrosPorSegundo))
                        {
                            ciclista.Velocidad = 0;
                        }
                        else
                        {
                            ciclista.Velocidad = Math.Round(metrosPorSegundo, 2);
                        }
                    }
                }
                Session["Ciclistas"] = ciclistas;
            }
            return RedirectToAction("Index");
        }

    }
}

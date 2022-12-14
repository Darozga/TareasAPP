using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Web.Interfaz.Models;

namespace Web.Interfaz.Controllers
{
    public class TareasController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7225/api");
        HttpClient client;

        public TareasController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }

        /// <summary>        
        /// Metodo que consulta al api para obtener todas las tareas     
        /// </summary>
        public ActionResult Index()
        {
            try
            {
                var errMsg = TempData["ErrorMessage"] as string;

                Respuesta<IEnumerable<TareaModel>> objRespuesta = new Respuesta<IEnumerable<TareaModel>>();
                cargarListas();
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/tareas").Result;
                if (response.IsSuccessStatusCode)
                {

                    string data = response.Content.ReadAsStringAsync().Result;
                    objRespuesta = JsonConvert.DeserializeObject<Respuesta<IEnumerable<TareaModel>>>(data);
                    if (!objRespuesta.Success)
                    {
                        Error errorMessage = new Error();
                        errorMessage.ErrorMessage = objRespuesta.strMensajeRespuesta;
                        return View("Error", errorMessage);
                    }
                }
                else
                {
                    return View("Error");
                }
                if (errMsg != null)
                {
                    ModelState.AddModelError("Error", errMsg);

                }

                return View(objRespuesta.ValorRetorno);
            }
            catch (Exception)
            {

                return View("Error");
            }

        }

        /// <summary>        
        /// Metodo que consulta al api para obtener todas las tareas filtradas     
        /// </summary>
        [HttpPost]
        public ActionResult Index(FilterModel filtros)
        {
            try
            {
                Respuesta<IEnumerable<TareaModel>> objRespuesta = new Respuesta<IEnumerable<TareaModel>>();
                string data = JsonConvert.SerializeObject(filtros);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/tareas/filtro", content).Result;
                cargarListas();
                if (response.IsSuccessStatusCode)
                {
                    string data1 = response.Content.ReadAsStringAsync().Result;
                    objRespuesta = JsonConvert.DeserializeObject<Respuesta<IEnumerable<TareaModel>>>(data1);
                    if (!objRespuesta.Success)
                    {
                        Error errorMessage = new Error();
                        errorMessage.ErrorMessage = objRespuesta.strMensajeRespuesta;
                        return View("Error", errorMessage);
                    }
                }
                else
                {
                    return View("Error");
                }
                return View(objRespuesta.ValorRetorno);
            }
            catch (Exception)
            {
                return View("Error");

            }


        }

        public ActionResult Create()
        {
            try
            {
                cargarListas();
                return View();
            }
            catch (Exception)
            {
                return View("Error");

            }

        }

        /// <summary>        
        /// Metodo que consulta al api para obtener todas las lista(Colavorador, Prioridad, Estado)
        /// que se deben cargar en el sistema.
        /// </summary>
        public void cargarListas()
        {
            try
            {
                Respuesta<IEnumerable<ColaboradorModel>> objRespuesta = new Respuesta<IEnumerable<ColaboradorModel>>();

                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/colaborador").Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    objRespuesta = JsonConvert.DeserializeObject<Respuesta<IEnumerable<ColaboradorModel>>>(data);
                    ViewBag.colaboradores = objRespuesta.ValorRetorno;
                }


                Respuesta<IEnumerable<PrioridadModel>> RespuestaPrioridades = new Respuesta<IEnumerable<PrioridadModel>>();

                HttpResponseMessage responsePrioridades = client.GetAsync(client.BaseAddress + "/prioridad").Result;
                if (responsePrioridades.IsSuccessStatusCode)
                {
                    string data = responsePrioridades.Content.ReadAsStringAsync().Result;
                    RespuestaPrioridades = JsonConvert.DeserializeObject<Respuesta<IEnumerable<PrioridadModel>>>(data);
                    ViewBag.prioridades = RespuestaPrioridades.ValorRetorno;
                }

                Respuesta<IEnumerable<EstadoModel>> RespuestaEstados = new Respuesta<IEnumerable<EstadoModel>>();

                HttpResponseMessage responseEstado = client.GetAsync(client.BaseAddress + "/estado").Result;
                if (responseEstado.IsSuccessStatusCode)
                {
                    string data = responseEstado.Content.ReadAsStringAsync().Result;
                    RespuestaEstados = JsonConvert.DeserializeObject<Respuesta<IEnumerable<EstadoModel>>>(data);
                    ViewBag.estados = RespuestaEstados.ValorRetorno;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        /// <summary>        
        /// Metodo para crear una nueva tarea     
        /// </summary>
        [HttpPost]
        public ActionResult Create(TareaModel obj, FormCollection form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cargarListas();
                    if (obj.Fecha_Inicio > obj.Fecha_Fin)
                    {
                        ModelState.AddModelError("CustomError", "La fecha de incio no puede ser menor a la fecha fin.");
                        return View(obj);
                    }

                    if (obj.Colaborador_Id == null && obj.Estado_Id != 1)
                    {
                        ModelState.AddModelError("CustomError", "Debes selecionar un colaborador");
                        return View(obj);
                    }
                }
                string data = JsonConvert.SerializeObject(obj);
                Respuesta<bool> objRespuesta = new Respuesta<bool>();
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/tareas", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string respuestaApi = response.Content.ReadAsStringAsync().Result;
                    objRespuesta = JsonConvert.DeserializeObject<Respuesta<bool>>(respuestaApi);
                    if (!objRespuesta.Success)
                    {
                        Error errorMessage = new Error();
                        errorMessage.ErrorMessage = objRespuesta.strMensajeRespuesta;
                        return View("Error", errorMessage);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception)
            {

                return View("Error");

            }



        }

        /// <summary>        
        /// Metodo para editar una tarea     
        /// </summary>
        public ActionResult Editar(int id)
        {
            try
            {
                Error errorMessage = new Error();
                Respuesta<TareaModel> objRespuesta = new Respuesta<TareaModel>();
                HttpResponseMessage responseTareas = client.GetAsync(client.BaseAddress + "/tareas/" + id).Result;
                if (responseTareas.IsSuccessStatusCode)
                {
                    string data = responseTareas.Content.ReadAsStringAsync().Result;
                    objRespuesta = JsonConvert.DeserializeObject<Respuesta<TareaModel>>(data);
                    if (!objRespuesta.Success)
                    {
                        
                        errorMessage.ErrorMessage = objRespuesta.strMensajeRespuesta;
                        return View("Error", errorMessage);
                    }
                }
                else
                {
                    return View("Error");
                }
                cargarListas();
                return View("Editar", objRespuesta.ValorRetorno);
            }
            catch (Exception)
            {

                return View("Error");
            }

        }

        /// <summary>        
        /// Metodo para eliminar una tarea    
        /// </summary>
        [HttpGet]
        public ActionResult Eliminar(int id, int estado)
        {
            try
            {
                Respuesta<bool> objRespuesta = new Respuesta<bool>();
                HttpResponseMessage responseTareas = client.DeleteAsync(client.BaseAddress + "/tareas/" + id).Result;
                if (responseTareas.IsSuccessStatusCode)
                {
                    string data = responseTareas.Content.ReadAsStringAsync().Result;
                    objRespuesta = JsonConvert.DeserializeObject<Respuesta<bool>>(data);
                    if (!objRespuesta.Success)
                    {
                        Error errorMessage = new Error();
                        errorMessage.ErrorMessage = objRespuesta.strMensajeRespuesta;
                        return View("Error", errorMessage);
                    }
                }
                else
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View("Error");

            }

        }

        /// <summary>        
        /// Metodo para actualizar una tarea     
        /// </summary>
        [HttpPost]
        public ActionResult Editar(TareaModel obj, FormCollection form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cargarListas();
                    if (obj.Fecha_Inicio > obj.Fecha_Fin)
                    {
                        ModelState.AddModelError("CustomError", "La fecha de incio no puede ser menor a la fecha fin.");
                        return View(obj);
                    }

                    if (obj.Colaborador_Id == null && obj.Estado_Id != 1)
                    {
                        ModelState.AddModelError("CustomError", "Debes selecionar un colaborador");
                        return View(obj);
                    }
                }

                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                Respuesta<bool> objRespuesta = new Respuesta<bool>();
                HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/tareas", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string respuestaApi = response.Content.ReadAsStringAsync().Result;
                    objRespuesta = JsonConvert.DeserializeObject<Respuesta<bool>>(respuestaApi);
                    if (!objRespuesta.Success)
                    {
                        Error errorMessage = new Error();
                        errorMessage.ErrorMessage = objRespuesta.strMensajeRespuesta;
                        return View("Error", errorMessage);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception)
            {

                return View("Error");
            }


        }
    }
}
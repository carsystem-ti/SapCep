using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Net.Http;
using System.Collections;
using System.Text.RegularExpressions;
using System.Net;
using System.Web.Http;

namespace SapCep.Controllers
{
    public class HomeController : System.Web.Http.ApiController
    {

        [System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.Route("ValidaCep")]
        public IHttpActionResult ValidaCep()
        {


            return Ok("");
        }

        private static readonly HttpClient _httpClient = new HttpClient();


        public static ArrayList BuscaCep(string cep)
        {
            
            /// request.AllowAutoRedirect = false;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + cep + "/json/");
            HttpWebResponse ChecaServidor = (HttpWebResponse)request.GetResponse();
            ArrayList Lista = new ArrayList();
            request.AllowAutoRedirect = false;




            using (Stream webStream = ChecaServidor.GetResponseStream())
            {
                if (webStream != null)
                {
                    using (StreamReader responseReader = new StreamReader(webStream))
                    {
                        string response = responseReader.ReadToEnd();
                        response = Regex.Replace(response, "[{},]", string.Empty);
                        response = response.Replace("\"", "");

                        String[] substrings = response.Split('\n');

                        int cont = 0;
                        foreach (var substring in substrings)
                        {
                            if (cont == 1)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                if (valor[0] == "  erro")
                                {
                                    //MessageBox.Show("CEP não encontrado");
                                    //txtCep.Focus();
                                    //return;
                                }
                            }

                            //Logradouro
                            if (cont == 2)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                Lista.Add(valor[1]);
                            }

                            //Complemento
                            if (cont == 3)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                Lista.Add(valor[1]);
                            }

                            //Bairro
                            if (cont == 4)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                Lista.Add(valor[1]);
                            }

                            //Localidade (Cidade)
                            if (cont == 5)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                Lista.Add(valor[1]);
                            }

                            //Estado (UF)
                            if (cont == 6)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                Lista.Add(valor[1]);
                            }
                            if (cont == 7)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                Lista.Add(valor[1]);
                            }
                            if (cont == 8)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                Lista.Add(valor[1]);
                            }


                            cont++;
                        }
                    }
                }
            }
          
            return Lista;
        }
    }
}

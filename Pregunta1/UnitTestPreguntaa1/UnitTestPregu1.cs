using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta1.Controllers;
using Pregunta1.Models;

namespace UnitTestPreguntaa1
{
    [TestClass]
    public class UnitTestPregu1
    {
        [TestMethod]
        public void TestGet()
        {
            //Arrange
            herediasController controller = new herediasController();

            //Act
            var ResultadoG = controller.Getheredias();

            //Assert
            Assert.IsNotNull(ResultadoG);
        }

        [TestMethod]
        public void TestPost()
        {
            //Arrange
            herediasController controller = new herediasController();
            heredia esperado = new heredia()
            {
                herediaID = 1,
                Friendofheredia = "Alberto Marin",
                Place = PlaceType.Universidad,
                Email = "alberto@gmail.com",
                Birthday = DateTime.Today
            };

            //Act
            IHttpActionResult actionResult = controller.Postheredia(esperado);
            var CreadoPo = actionResult as CreatedAtRouteNegotiatedContentResult<heredia>;

            //Assert
            Assert.IsNotNull(CreadoPo);
            Assert.AreEqual("DefaultApi", CreadoPo.RouteName);
            Assert.IsNotNull(CreadoPo.RouteValues["id"]);
        }

        [TestMethod]
        public void TestPut()
        {
            //Arrange
            herediasController controller = new herediasController();
            heredia esperado = new heredia()
            {
                herediaID = 2,
                Friendofheredia = "Juan",
                Place = PlaceType.Casa,
                Email = "albert@gmail.com",
                Birthday = DateTime.Today
            };

            //Act
            IHttpActionResult actionResult = controller.Postheredia(esperado);
            var Resultado = controller.Putheredia(esperado.herediaID,esperado) as StatusCodeResult;

            //Assert
            Assert.IsNotNull(Resultado);
            Assert.IsInstanceOfType(Resultado, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, Resultado.StatusCode);
        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            herediasController controller = new herediasController();
            heredia esperado = new heredia()
            {
                herediaID = 3,
                Friendofheredia = "Paco",
                Place = PlaceType.Restaurante,
                Email = "alber@gmail.com",
                Birthday = DateTime.Today
            };

            //Act
            IHttpActionResult actionResultPost = controller.Postheredia(esperado);
            IHttpActionResult actionResultDelete = controller.Deleteheredia(esperado.herediaID);

            //Assert
            Assert.IsInstanceOfType(actionResultDelete, typeof(OkNegotiatedContentResult<heredia>));
        }
    }
}

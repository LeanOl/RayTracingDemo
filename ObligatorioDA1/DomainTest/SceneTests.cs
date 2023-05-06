using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using Domain;

namespace DomainTest
{
    [TestClass]
    public class SceneTests
    {
        [TestMethod]
        public void CreateSceneSuccessfully()
        {
            Image preview = null;
            Scene scene = new Scene()
            {
                Proprietary = new Client(),
                Name = "Scene",
                CreationDate = DateTime.Now,
                ModelList= new List<PositionedModel>(),
                Camera = new Camera(),
                LastModified= DateTime.Now,
                LastRendered= DateTime.Now,
                Preview= preview
                
            };
        }
    }
}

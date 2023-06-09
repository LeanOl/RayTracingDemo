using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace LogicTest
{
    [TestClass]

    public class FigureTests
    {
        private Client someClient;
        private const string validName = "Ball";
        private const int validRadius = 10;
        private const string someUsername = "Pepito";
        private const string validFigureName = "Ball";
        private const decimal negativeRadius = -5;
        private const string invalidRadiusMessage = "Radius must be a positive decimal number";
        private const string invalidEmptyNameMessage = "The name must not be empty";
        private const string invalidNameWithSpacesMessage = "Name must not start or end with spaces";

        [TestInitialize]
        public void TestInit()
        {            
            someClient = new Client()
            {
                Username = someUsername
            };
        }

        [TestMethod]
        public void CreateSphereObjectSuccesfully()
        {
            Sphere aSphere = new Sphere()
            {
                Proprietary = someClient,
                Name = validName,
                Radius = validRadius
            };

            Assert.IsNotNull(aSphere);
            Assert.AreEqual(someClient, aSphere.Proprietary);
            Assert.AreEqual(validName, aSphere.Name);
            Assert.AreEqual(validRadius, aSphere.Radius);
        }

        [TestMethod]
        public void SphereHitReturnHitRecord()
        {
            Sphere aSphere = new Sphere()
            {
                Proprietary = someClient,
                Name = validName,
                Radius = 0.5m
            };
            Ray aRay = new Ray()
            {
                Origin = new Vector { X = 0, Y = 0, Z = 0 },
                Direction = new Vector { X = 0, Y = 0.56m, Z = -1 }
            };
            Vector center = new Vector { X = 0, Y = 0, Z = -1 };
            HitRecord hit = aSphere.Hit(aRay, 0, 5, center);
            Assert.IsNotNull(hit);
        }

        [TestMethod]
        public void SphereHitReturnNullWhenNotHit()
        {
            Sphere aSphere = new Sphere()
            {
                Proprietary = someClient,
                Name = validName,
                Radius = 0.5m
            };
            Ray aRay = new Ray()
            {
                Origin = new Vector { X = 0, Y = 0, Z = 0 },
                Direction = new Vector { X = -2, Y = 0.98m, Z = -1 }
            };
            Vector center = new Vector { X = 0, Y = 0, Z = -1 };
            HitRecord hit = aSphere.Hit(aRay, 0, 5, center);
            Assert.IsNull(hit);
        }

        [TestMethod]
        public void SphereHitReturnCorrectHitRecordWhenHit()
        {
            Sphere aSphere = new Sphere()
                        {
                Proprietary = someClient,
                Name = validName,
                Radius = 0.5m
            };
            Ray aRay = new Ray()
            {
                Origin = new Vector { X = 0, Y = 0, Z = 0 },
                Direction = new Vector { X = 0, Y = 0.56m, Z = -1 }
            };
            Vector center = new Vector { X = 0, Y = 0, Z = -1 };
            HitRecord hit = aSphere.Hit(aRay, 0, 5, center);
            decimal expectedT = 0.66865m;
            decimal expectedInPointX = 0;
            decimal expectedInPointY = 0.37444m;
            decimal expectedInPointZ = -0.66865m;
            decimal expectedNormalX = 0;
            decimal expectedNormalY = 0.74889m;
            decimal expectedNormalZ = 0.66269m;
            int fiveDecimals = 100000;
            Assert.AreEqual(expectedT, Math.Truncate(hit.T*fiveDecimals)/fiveDecimals);
            Assert.AreEqual(expectedInPointX, Math.Truncate(hit.IntersectionPoint.X*fiveDecimals)/fiveDecimals);
            Assert.AreEqual(expectedInPointY, Math.Truncate(hit.IntersectionPoint.Y*fiveDecimals)/fiveDecimals);
            Assert.AreEqual(expectedInPointZ, Math.Truncate(hit.IntersectionPoint.Z*fiveDecimals)/fiveDecimals);
            Assert.AreEqual(expectedNormalX, Math.Truncate(hit.Normal.X*fiveDecimals)/fiveDecimals);
            Assert.AreEqual(expectedNormalY, Math.Truncate(hit.Normal.Y*fiveDecimals)/fiveDecimals);
            Assert.AreEqual(expectedNormalZ, Math.Truncate(hit.Normal.Z*fiveDecimals)/fiveDecimals);

        }
        [TestMethod]
        public void SphereHitReturnNullTIsLessThanTmin()
        {
            Sphere aSphere = new Sphere()
            {
                Proprietary = someClient,
                Name = validName,
                Radius = 0.5m
            };
            Ray aRay = new Ray()
            {
                Origin = new Vector { X = 0, Y = 0, Z = 0 },
                Direction = new Vector { X = 0, Y = 0.56m, Z = -1 }
            };
            Vector center = new Vector { X = 0, Y = 0, Z = -1 };
            HitRecord hit = aSphere.Hit(aRay, 0.7m, 5, center);
            Assert.IsNull(hit);
        }
        [TestMethod]
        public void SphereHitReturnNullTIsMoreThanTmax()
        {
            Sphere aSphere = new Sphere()
            {
                Proprietary = someClient,
                Name = validName,
                Radius = 0.5m
            };
            Ray aRay = new Ray()
            {
                Origin = new Vector { X = 0, Y = 0, Z = 0 },
                Direction = new Vector { X = 0, Y = 0.56m, Z = -1 }
            };
            Vector center = new Vector { X = 0, Y = 0, Z = -1 };
            HitRecord hit = aSphere.Hit(aRay, 0, 0.5m, center);
            Assert.IsNull(hit);
        }

        [TestMethod]
        public void GeneratePreviewFigureSphere()
        {
            Figure aSphere = new Sphere()
            {
                Proprietary = someClient,
                Name = validName,
                Radius = 0.5m
            };
            Figure previewSphere = aSphere.GeneratePreviewFigure();
            Assert.IsNotNull(previewSphere);
            
        }

        [TestMethod]
        public void InvalidEmptyNameError()
        {
            Exception exceptionCaught = null;

            Sphere invalidFigure = new Sphere()
            {
                Proprietary = someClient,
                Name = "",
                Radius = validRadius
            };

            try
            {
                invalidFigure.Validate();
            }
            catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            Assert.IsNotNull(exceptionCaught);
            Assert.IsInstanceOfType(exceptionCaught, typeof(ArgumentException));
            Assert.AreEqual(exceptionCaught.Message, invalidEmptyNameMessage);

        }

        [TestMethod]
        public void InvalidNameWithSpacesInBeginning()
        {
            Exception exceptionCaught = null;

            Sphere invalidFigure = new Sphere()
            {
                Proprietary = someClient,
                Name = "   ball",
                Radius = validRadius
            };

            try
            {
                invalidFigure.Validate();
            }
            catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            Assert.IsNotNull(exceptionCaught);
            Assert.IsInstanceOfType(exceptionCaught, typeof(ArgumentException));
            Assert.AreEqual(exceptionCaught.Message, invalidNameWithSpacesMessage);

        }

        [TestMethod]
        public void InvalidNameWithSpacesInBeginningOrEndError()
        {
            Exception exceptionCaught = null;;

            Sphere invalidFigure = new Sphere()
            {
                Proprietary = someClient,
                Name = "   ball  ",
                Radius = validRadius
            };

            try
            {
                invalidFigure.Validate();
            }
            catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            Assert.IsNotNull(exceptionCaught);
            Assert.IsInstanceOfType(exceptionCaught, typeof(ArgumentException));
            Assert.AreEqual(exceptionCaught.Message, invalidNameWithSpacesMessage);

        }

        [TestMethod]
        public void InvalidNameWithSpacesInEnd()
        {
            Exception exceptionCaught = null;

            Sphere invalidFigure = new Sphere()
            {
                Proprietary = someClient,
                Name = "ball    ",
                Radius = validRadius
            };

            try
            {
                invalidFigure.Validate();
            }
            catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            Assert.IsNotNull(exceptionCaught);
            Assert.IsInstanceOfType(exceptionCaught, typeof(ArgumentException));
            Assert.AreEqual(exceptionCaught.Message, invalidNameWithSpacesMessage);

        }

        [TestMethod]
        public void InvalidRadiusError()
        {
            Exception exceptionCaught = null;

            Sphere invalidFigure = new Sphere()
            {
                Proprietary = someClient,
                Name = validFigureName,
                Radius = negativeRadius
            };

            try
            {
                invalidFigure.Validate();

            }
            catch (Exception ex)
            {
                exceptionCaught = ex;
            }

            Assert.IsNotNull(exceptionCaught);
            Assert.IsInstanceOfType(exceptionCaught, typeof(ArgumentException));
            Assert.AreEqual(exceptionCaught.Message, invalidRadiusMessage);

        }
    }
}

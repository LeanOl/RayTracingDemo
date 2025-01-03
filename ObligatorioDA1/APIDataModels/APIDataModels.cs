using System.Drawing;
using Domain;

namespace APIDataModels
{
    public class CreateClientRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Client ToObject()
        {
            return new Client
            {
                Username = Username,
                Password = Password
            };
        }
    }
    public class ProprietaryRequest
    {
        public string Username { get; set; }

        public Client ToObject()
        {
            return new Client
            {
                Username = Username,
                Password = ""
            };
        }
    }

    public class ColorRequest
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public Color ToObject()
        {
            return Color.FromArgb(R, G, B);
        }
    }

    public class CreateMaterialRequest
    {
        public ProprietaryRequest Proprietary { get; set; }
        public string Name { get; set; }
        public ColorRequest Color { get; set; }
        public string Type { get; set; }

        public double? Roughness { get; set; }

        public Material ToObject()
        {
            if (Type.ToLower() == "lambertian")
            {
                return new Lambertian
                {
                    Name = Name,
                    Proprietary = Proprietary.ToObject(),
                    Color = Color.ToObject()
                };
            }
            else if (Type.ToLower() == "metallic")
            {
                return new Metallic
                {
                    Name = Name,
                    Proprietary = Proprietary.ToObject(),
                    Color = Color.ToObject(),
                    Roughness = Roughness ?? 0
                };
            }
            return new Lambertian
            {
                Name = Name,
                Proprietary = Proprietary.ToObject(),
                Color = Color.ToObject()
            };
        }
    }
            

        

        public class LogInRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class ClientRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class GetMaterialsByClientRequest
        {
            public string Username { get; set; }
        }

        public class DeleteMaterialRequest
        {
            public string Name { get; set; }
            public string Username { get; set; }

            public Material ToObject()
            {
                return new Lambertian
                {
                    Name = Name,
                    Proprietary = new Client
                    {
                        Username = Username,
                        Password = ""
                    }
                };
            }
        }

        public class CreateFigureRequest
        {
            public string Name { get; set; }
            public string Username { get; set; }
            public double Radius { get; set; }

            public Sphere ToObject()
            {
                return new Sphere
                {
                    Name = Name,
                    Proprietary = new Client
                    {
                        Username = Username,
                        Password = ""
                    },
                    Radius = Radius
                };
            }
        }

        public class DeleteFigureRequest
        {
            public string Name { get; set; }
            public string Username { get; set; }
            public Figure ToObject()
            {
                return new Sphere
                {
                    Name = Name,
                    Proprietary = new Client
                    {
                        Username = Username,
                        Password = ""
                    }
                };
            }
        }

        public class GetFiguresByClientRequest
        {
            public string Username { get; set; }
        }

        public class CreateModelRequest
        {
            public string Name { get; set; }
            public ProprietaryRequest Proprietary { get; set; }
            public CreateFigureRequest Figure { get; set; }
            public CreateMaterialRequest Material { get; set; }

            public bool HasPreview { get; set; }

            public Model ToObject()
            {
                return new Model
                {
                    Name = Name,
                    Proprietary = Proprietary.ToObject(),
                    Figure = Figure.ToObject(),
                    Material = Material.ToObject()
                };
            }

        }
    }


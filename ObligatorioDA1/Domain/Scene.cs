using System;
using System.Collections.Generic;
using System.Drawing;

namespace Domain
{
    public class Scene
    {
        public Image Preview { get; set; }
        public Client Proprietary { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<PositionedModel> ModelList { get; set; }
        public Camera Camera { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime LastRendered { get; set; }
    }
}
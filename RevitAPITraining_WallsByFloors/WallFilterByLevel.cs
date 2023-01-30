using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining_WallsByFloors
{
    internal class WallFilterByLevel : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            throw new NotImplementedException();
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }
}

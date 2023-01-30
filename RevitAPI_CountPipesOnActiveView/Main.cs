using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI_CountPipesOnActiveView
{
    [Transaction(TransactionMode.Manual)]

    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application; // -> Revit
            UIDocument uidoc = uiapp.ActiveUIDocument; // текущий документ
            Document doc = uidoc.Document; // обращение к безе данных текужего документа

            List<Pipe> pipe = new FilteredElementCollector(doc, doc.ActiveView.Id) //системное семейство
                                .OfCategory(BuiltInCategory.OST_PipeCurves)
                                .WhereElementIsNotElementType()
                                .Cast<Pipe>()
                                .ToList();


            TaskDialog.Show("PipeCurves count", pipe.Count.ToString());


            return Result.Succeeded;
        }
    }
}

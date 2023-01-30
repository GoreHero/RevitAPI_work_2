using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI_CountDucts
{
    [Transaction(TransactionMode.Manual)]

    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements) //CommandData -> журнал ревита
        {
            UIApplication uiapp = commandData.Application; // -> Revit
            UIDocument uidoc = uiapp.ActiveUIDocument; // текущий документ
            Document doc = uidoc.Document; // обращение к безе данных текужего документа

            List<Duct> duct = new FilteredElementCollector(doc) //системное семейство
                .OfCategory(BuiltInCategory.OST_DuctCurves)
                .WhereElementIsNotElementType()
                .Cast<Duct>()
                .ToList();
            TaskDialog.Show("DuctCurves count", duct.Count.ToString());

            return Result.Succeeded;
        }
    }
}

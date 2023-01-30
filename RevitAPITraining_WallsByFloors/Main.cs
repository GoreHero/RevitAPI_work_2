using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraining_WallsByFloors
{
    [Transaction(TransactionMode.Manual)]

    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application; // -> Revit
            UIDocument uidoc = uiapp.ActiveUIDocument; // текущий документ
            Document doc = uidoc.Document; // обращение к безе данных текужего документа

            ElementCategoryFilter wallCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_Walls);
            ElementId elementIdLevelOne = new FilteredElementCollector(doc)
                .OfClass(typeof(Level))
                .Where(x=>x.Name.Equals("Level 1"))
                .FirstOrDefault().Id;

            ElementId elementIdLevelTwo = new FilteredElementCollector(doc)
                .OfClass(typeof(Level))
                .Where(x => x.Name.Equals("Level 2"))
                .FirstOrDefault().Id;

            ElementLevelFilter elementLevelOneFilter = new ElementLevelFilter(elementIdLevelOne);
            LogicalAndFilter elementWallsOneFilter = new LogicalAndFilter(wallCategoryFilter, elementLevelOneFilter);

            ElementLevelFilter elementLevelTwoFilter = new ElementLevelFilter(elementIdLevelTwo);
            LogicalAndFilter elementWallsTwoFilter = new LogicalAndFilter(wallCategoryFilter, elementLevelTwoFilter);

            var walls1 = new FilteredElementCollector(doc)
                .WherePasses(elementWallsOneFilter)
                .Cast<Wall>()
                .ToList();

            var walls2 = new FilteredElementCollector(doc)
                .WherePasses(elementWallsTwoFilter)
                .Cast<Wall>()
                .ToList();


            TaskDialog.Show("Walls count on level 1" , walls1.Count.ToString());
            TaskDialog.Show("Walls count on level 2" , walls2.Count.ToString());

            return Result.Succeeded;
        }
    }
}

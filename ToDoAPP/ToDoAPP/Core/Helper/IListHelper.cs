using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ToDoApp.Core.Helper
{
    public static class IListHelper
    {

        // Global extension method for converting List<T> to ObservableCollection<T>
        // Static conversion methods
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> from)
        {
            ObservableCollection<T> to = new ObservableCollection<T>();
            //Extraction of conversion methods into static methods of static classes
            foreach (var i in from)
            {
                to.Add(i);
            }
            return to;
        }
        //method essentially does the conversion by iterating over the elements of the source collection fromList and adding them to the target collection toList
    }
}

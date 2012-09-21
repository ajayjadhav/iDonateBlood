using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace iDonateBlood
{

    public class DateTypeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                string lastDonatedDate = value.ToString();
                if (lastDonatedDate != "")
                {
                    DateTimeFormatInfo formatA = new DateTimeFormatInfo();
                    DateTime Date = DateTime.Parse(lastDonatedDate.ToString(), formatA);
                    return Date.ToString(" MM/dd/yyyy");
                }
            }
            return null;

        }


        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCanteen.Helpers
{
    // For more detailed information see:
    // Creating XAML Markup Extensions
    // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/xaml/markup-extensions/creating

    [ContentProperty(nameof(Icon))]
    public class IconResourceExtension : IMarkupExtension<ImageSource>
    {
        public string Icon { get; set; }

        public ImageSource ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Icon))
            {
                IXmlLineInfoProvider lineInfoProvider = serviceProvider.GetService(
                    typeof(IXmlLineInfoProvider)) as IXmlLineInfoProvider;
                IXmlLineInfo lineInfo = (lineInfoProvider != null) ?
                    lineInfoProvider.XmlLineInfo : new XmlLineInfo();
                throw new XamlParseException(
                    "ImageResourceExtension requires Source property to be set", lineInfo);
            }
            string assemblyName = GetType().GetTypeInfo().Assembly.GetName().Name;
            var imageSource = ImageSource.FromResource(assemblyName + "." + Icon,
                typeof(IconResourceExtension).GetTypeInfo().Assembly);
            //var imageSource = ImageSource.FromResource(Source);

            return imageSource;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<ImageSource>).ProvideValue(serviceProvider);
        }
    }
}

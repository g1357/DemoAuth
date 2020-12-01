using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCanteen.Helpers
{
    [ContentProperty("FlyoutIcon")]
    public class FlyoutIconResourceExtension : IMarkupExtension<ImageSource>
    {
        public string FlyoutIcon { get; set; }

        public ImageSource ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(FlyoutIcon))
            {
                IXmlLineInfoProvider lineInfoProvider = serviceProvider.GetService(
                    typeof(IXmlLineInfoProvider)) as IXmlLineInfoProvider;
                IXmlLineInfo lineInfo = (lineInfoProvider != null) ?
                    lineInfoProvider.XmlLineInfo : new XmlLineInfo();
                throw new XamlParseException(
                    "ImageResourceExtension requires Source property to be set", lineInfo);
            }
            string assemblyName = GetType().GetTypeInfo().Assembly.GetName().Name;
            var imageSource = ImageSource.FromResource(assemblyName + "." + FlyoutIcon,
                typeof(ImageResourceExtension).GetTypeInfo().Assembly);
            //var imageSource = ImageSource.FromResource(Source);

            return imageSource;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<ImageSource>).ProvideValue(serviceProvider);
        }
    }
}

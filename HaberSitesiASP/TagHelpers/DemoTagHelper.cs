using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesiASP.TagHelpers
{
    public class DemoTagHelper : TagHelper
    {
        public string Status { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<div>");
            builder.AppendLine($"<span>{Status}</span>");
            builder.AppendLine("</div>");

            output.Content.SetHtmlContent(builder.ToString());
        }
    }
}

using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesiASP.TagHelpers
{
    public class SubmitTagHelper : TagHelper
    {
        public string Class { get; set; }
        public string Value { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            
            output.Content.SetHtmlContent(
                   $"<button type='submit' class='{Class}'>{Value}</button>"
                  );

        }
    }
}

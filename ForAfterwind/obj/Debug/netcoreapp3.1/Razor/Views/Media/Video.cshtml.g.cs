#pragma checksum "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Video.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b1f0d472017dd47dec0d7bd92d85a92facfd2a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Media_Video), @"mvc.1.0.view", @"/Views/Media/Video.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b1f0d472017dd47dec0d7bd92d85a92facfd2a7", @"/Views/Media/Video.cshtml")]
    public class Views_Media_Video : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ForAfterwind.Models.VideoAlbum>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Video.cshtml"
  
    ViewData["Title"] = "Video";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<div class=\"container\">\n    <div id=\"unhiddenInfo\" class=\"row background__dark unhiddenVideo\">\n\n    </div>\n    \n    <div id=\"hiddenInfo\" class=\"row background__dark overflow-auto hiddenVideo\">\n");
#nullable restore
#line 14 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Video.cshtml"
         foreach (var el in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"video-album col-md-3 col-sm-6\">\n            <div onclick=\"showAlbum(this)\">\n                <h3>");
#nullable restore
#line 18 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Video.cshtml"
               Write(el.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n                <button class=\"close\">Close</button>\n                <img class=\"video-album_cover\"");
            BeginWriteAttribute("src", " src=\"", 559, "\"", 593, 1);
#nullable restore
#line 20 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Video.cshtml"
WriteAttributeValue("", 565, Url.Content(el.PathToCover), 565, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 594, "\"", 621, 1);
#nullable restore
#line 20 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Video.cshtml"
WriteAttributeValue("", 600, Url.Content(el.Name), 600, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n\n            </div>\n            <div class=\"info hidden col-md\">\n                <div class=\"row overflow-auto video-row justify-content-around\">\n");
#nullable restore
#line 25 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Video.cshtml"
                     foreach (var item in el.Videos)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-md-5\">\n                            <div class=\"video-container background__dark\">\n                                <p>");
#nullable restore
#line 29 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Video.cshtml"
                              Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                                <video class=\"video-player\"");
            BeginWriteAttribute("src", " src=\"", 1078, "\"", 1114, 1);
#nullable restore
#line 30 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Video.cshtml"
WriteAttributeValue("", 1084, Url.Content(item.PathToVideo), 1084, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" controls=\"controls\" controlsList=\"nodownload\"></video>\n                            </div>\n                        </div>\n");
#nullable restore
#line 33 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Video.cshtml"
                     }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\n\n            </div>\n        </div>\n");
#nullable restore
#line 38 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Video.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n\n    \n</div>\n\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ForAfterwind.Models.VideoAlbum>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Audio.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58a5da24bb9104106284454cbf5b624f56fc1d6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Media_Audio), @"mvc.1.0.view", @"/Views/Media/Audio.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58a5da24bb9104106284454cbf5b624f56fc1d6c", @"/Views/Media/Audio.cshtml")]
    public class Views_Media_Audio : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ForAfterwind.Domain.Release>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <div id=\"unhiddenInfo\" class=\"row overflow-auto background__dark\">\r\n\r\n    </div>\r\n    <div id=\"hiddenInfo\" class=\"row background__dark\">\r\n\r\n");
#nullable restore
#line 10 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Audio.cshtml"
         foreach (var el in Model)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Audio.cshtml"
             if (el.Name == "")
            {
                continue;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-sm-6 col-md-3 d-flex album scale\">\r\n                <img class=\"album__cover\"");
            BeginWriteAttribute("src", "\r\n                     src=\"", 464, "\"", 520, 1);
#nullable restore
#line 18 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Audio.cshtml"
WriteAttributeValue("", 492, Url.Content(el.PathToCover), 492, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", "\r\n                     alt=\"", 521, "\"", 557, 1);
#nullable restore
#line 19 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Audio.cshtml"
WriteAttributeValue("", 549, el.Name, 549, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick=\"showAlbum(this)\" \r\n                     />\r\n                <div class=\"info hidden\">\r\n                    <div class=\"info-audio__content\">\r\n                        <h2>");
#nullable restore
#line 23 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Audio.cshtml"
                       Write(el.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                        <div class=\"audio-container overflow-auto\">\r\n");
#nullable restore
#line 25 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Audio.cshtml"
                             foreach (var item in el.Songs)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Audio.cshtml"
                                 if (item.Type.Value.ToString() == "Video")
                                {
                                    continue;
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"audio-player\">\r\n                                    <p>");
#nullable restore
#line 32 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Audio.cshtml"
                                  Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <audio id=\"audio-player\"");
            BeginWriteAttribute("src", "\r\n                                           src=\"", 1283, "\"", 1362, 1);
#nullable restore
#line 34 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Audio.cshtml"
WriteAttributeValue("", 1333, Url.Content(item.PathToSong), 1333, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                                           type=\"audio/mp3\" controls=\"controls\"\r\n                                           controlsList=\"nodownload\">\r\n                                    </audio>\r\n                                </div>\r\n");
#nullable restore
#line 39 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Audio.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 46 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Media\Audio.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ForAfterwind.Domain.Release>> Html { get; private set; }
    }
}
#pragma warning restore 1591

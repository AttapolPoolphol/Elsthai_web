#pragma checksum "C:\Users\early\Downloads\elsthai_web\elsthai_web\Views\Staff\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b2e2663b8ebcdf3270a0cd326949397f7a42fe3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Staff_Edit), @"mvc.1.0.view", @"/Views/Staff/Edit.cshtml")]
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
#nullable restore
#line 1 "C:\Users\early\Downloads\elsthai_web\elsthai_web\Views\_ViewImports.cshtml"
using elsthai_web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\early\Downloads\elsthai_web\elsthai_web\Views\_ViewImports.cshtml"
using elsthai_web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b2e2663b8ebcdf3270a0cd326949397f7a42fe3", @"/Views/Staff/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea82add8a066f03ffc524d8735954b1942e1da89", @"/Views/_ViewImports.cshtml")]
    public class Views_Staff_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<elsthai_web.Models.Staff>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\early\Downloads\elsthai_web\elsthai_web\Views\Staff\Edit.cshtml"
  
    ViewBag.Title = "Edit";
    var db = ViewData["data"] as Staff;

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n<h2>แก้ไข ผู้ใช้งาน</h2>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7b2e2663b8ebcdf3270a0cd326949397f7a42fe33769", async() => {
                WriteLiteral(@"
    <div class=""row"">
        <div class=""col-12"">
            <div class=""card"">
                <div class=""card-body"">

                    <h4 class=""card-title"">Details</h4>
                    <div class=""form-group row"">
                        <label for=""example-text-input"" class=""col-sm-2 col-form-label"">ID</label>
                        <div class=""col-sm-10"">
                            <input class=""form-control"" type=""text"" id=""user_id"" name=""user_id""");
                BeginWriteAttribute("value", " value=\"", 644, "\"", 664, 1);
#nullable restore
#line 18 "C:\Users\early\Downloads\elsthai_web\elsthai_web\Views\Staff\Edit.cshtml"
WriteAttributeValue("", 652, db.staff_id, 652, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" id=""example-text-input"" readonly>
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label for=""example-text-input"" class=""col-sm-2 col-form-label"">Name</label>
                        <div class=""col-sm-10"">
                            <input class=""form-control"" type=""text"" id=""name"" name=""name""");
                BeginWriteAttribute("value", " value=\"", 1051, "\"", 1069, 1);
#nullable restore
#line 24 "C:\Users\early\Downloads\elsthai_web\elsthai_web\Views\Staff\Edit.cshtml"
WriteAttributeValue("  ", 1059, db.name, 1061, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label for=""example-text-input"" class=""col-sm-2 col-form-label"">phone</label>
                        <div class=""col-sm-10"">
                            <input class=""form-control"" type=""text"" id=""phone"" name=""phone""");
                BeginWriteAttribute("value", " value=\"", 1426, "\"", 1443, 1);
#nullable restore
#line 30 "C:\Users\early\Downloads\elsthai_web\elsthai_web\Views\Staff\Edit.cshtml"
WriteAttributeValue("", 1434, db.phone, 1434, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label for=""example-text-input"" class=""col-sm-2 col-form-label"">email</label>
                        <div class=""col-sm-10"">
                            <input class=""form-control"" type=""text"" id=""email"" name=""email""");
                BeginWriteAttribute("value", " value=\"", 1800, "\"", 1817, 1);
#nullable restore
#line 36 "C:\Users\early\Downloads\elsthai_web\elsthai_web\Views\Staff\Edit.cshtml"
WriteAttributeValue("", 1808, db.email, 1808, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                        </div>
                    </div>
                    <div class=""form-group row"">
                        <label for=""example-text-input"" class=""col-sm-2 col-form-label"">password_user</label>
                        <div class=""col-sm-10"">
                            <input class=""form-control"" type=""password"" id=""password_user"" name=""password_user""");
                BeginWriteAttribute("value", " value=\"", 2202, "\"", 2228, 1);
#nullable restore
#line 42 "C:\Users\early\Downloads\elsthai_web\elsthai_web\Views\Staff\Edit.cshtml"
WriteAttributeValue("", 2210, db.password_staff, 2210, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                        </div>
                    </div>
                    <div class=""form-group row"">
                       
                        <div class=""col-sm-10"">
                            <input class=""form-control"" type=""hidden"" id=""isdelete"" name=""isdelete""");
                BeginWriteAttribute("value", " value=\"", 2515, "\"", 2535, 1);
#nullable restore
#line 48 "C:\Users\early\Downloads\elsthai_web\elsthai_web\Views\Staff\Edit.cshtml"
WriteAttributeValue("", 2523, db.isdelete, 2523, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
                        </div>
                    </div>
                    <div class=""form-group row"">

                        <div class=""col-sm-10"">
                            <button type=""submit"" class=""btn btn-primary"">ยืนยัน</button>
                        </div>
                    </div>

                </div>
            </div>
        </div> <!-- end col -->
    </div> <!-- end row -->
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<elsthai_web.Models.Staff> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\early\Downloads\elsthai_web\elsthai_web\Views\Reportdonet\CloudFS.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "637702fdc306cbf22862963df0e1f52c8ce84619"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reportdonet_CloudFS), @"mvc.1.0.view", @"/Views/Reportdonet/CloudFS.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"637702fdc306cbf22862963df0e1f52c8ce84619", @"/Views/Reportdonet/CloudFS.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea82add8a066f03ffc524d8735954b1942e1da89", @"/Views/_ViewImports.cshtml")]
    public class Views_Reportdonet_CloudFS : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE gtml>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "637702fdc306cbf22862963df0e1f52c8ce846193266", async() => {
                WriteLiteral("\r\n    <title></title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "637702fdc306cbf22862963df0e1f52c8ce846194255", async() => {
                WriteLiteral(@"
    Name    <input type=""NameTbox"" type=""text"" oninput=""Update(this.value,'name')"">
    RollNo  <input type=""RollTbox"" type=""text"" oninput=""Update(this.value,'roll')"">
    Section <input type=""SecTbox"" type=""text"" oninput=""Update(this.value,'sec')"">
    Gender  <input type=""GenTbox"" type=""text"" oninput=""Update(this.value,'gen')"">
    <hr>
    <button id=""insertBtn"">INSERT</button>
    <button id=""selectBtn"">SELECT</button>
    <button id=""updateBtn"">UPDATE</button>
    <button id=""deleteBtn"">DELETE</button>

    <script src=""https://www.gstatic.com/firebasejs/8.2.6/firebase-app.js""></script>
    <script src=""https://www.gstatic.com/firebasejs/8.2.6/firebase-auth.js""></script>
    <script src=""https://www.gstatic.com/firebasejs/8.2.6/firebase-firestore.js""></script>

    <script id=""MainScript"">

        let NameT = document.getElementById('NameTbox');
        let RollT = document.getElementById('RollTbox');
        let SecT = document.getElementById('SecTbox');
        let GenT = document");
                WriteLiteral(@".getElementById('GenTbox');

        let nameV = NameT.value;
        let rollV = RollTbox.value;
        let secV = SecTbox.value;
        let genV = GenTbox.value;

        function Update(val, type) {
            if (type == 'name') nameV = val;
            else if (type == 'roll') rollV = val;
            else if (type == 'sec') secV = val;
            else if (type == 'gen') genV = val;
        }

        //**********************donfiguartion*****************************//

        /*???????????? const ????????????????????? Copy ?????? firebase ?????????????????? 7:08 ????????????*/

        // For Firebase JS SDK v7.20.0 and later, measurementId is optional
        const firebaseConfig = {
            apiKey: ""AIzaSyDAmC5P4Yz1AA1fsZs_vkFmOvkkRoU2u7Y"",
            authDomain: ""kcs-database.firebaseapp.com"",
            databaseURL: ""https://kcs-database.firebaseio.com"",
            projectId: ""kcs-database"",
            storageBucket: ""kcs-database.appspot.com"",
            messagingSenderId: ""942140079361"",
            app");
                WriteLiteral(@"Id: ""1:942140079361:web:d06709c7bafe9440c2ef00"",
            measurementId: ""G-63XXEQFVS1""
        };


        firebase.initializeApp(firebaseConfig);
        let cloudDB = firebase.firestore();

        //***********************Writing Data*****************************

        //---Add Document with Auto Generated ID
        function Add_Doc_WithAutoID() {
            cloudDB.collection(""Students"").add(
                {
                    NameOfStd: nameV,
                    RollNo: Number(rollV),
                    Section: secV,
                    Gender: genV
                }
            )
                .then(function (docRef) {
                    console.log(""Document written with ID"", docRef.id);
                })
                .cath(function (error) {
                    console.log(""Error adding document"", error);
                })
        }

        //---Add Document with Custom ID
        function Add_Doc_WithID() {
            cloudDB.collection(""Student");
                WriteLiteral(@"s"").doc(rollV).set(
                {
                    NameOfStd: nameV,
                    RollNo: Number(rollV),
                    Section: secV,
                    Gender: genV
                }
            )
                .then(function () {
                    console.log(""Document written with ID"", rollV);
                })
                .cath(function (error) {
                    console.log(""Error adding document"", error);
                })
        }

        //**********************Updating Data*******************************

        //---Update Fields insert a document
        function Update_Fields_inDocument() {
            cloudDB.collection(""Students"").doc(rollV).update(
                {
                    NameOfStd: nameV,
                    Section: secV,
                    Gender: genV
                }
            )
                .then(function () {
                    console.log(""Document updated with ID"", rollV);
                })
      ");
                WriteLiteral(@"          .cath(function (error) {
                    console.log(""Error updating document"", error);
                })
        }

        //**********************Delteing Data*******************************

        //---Delete a document
        function DeleteDocument() {
            cloudDB.collection(""Students"").doc(rollV).delete()
                .then(function () {
                    console.log(""Document deleted with ID"", rollV);
                })
                .cath(function (error) {
                    console.log(""Error deleting document"", error);
                })
        }

        //**********************Reading Data*******************************

        //---Retrieve Data within a document
        function RetrieceData_inDocument() {
            cloudDB.collection(""Students"").doc(rollV).get()
                .then(function (doc) {
                    if (doc.exists) {
                        NameT.value = doc.data().NameOfStd;
                        SecT.valu");
                WriteLiteral(@"e = doc.data().Section;
                        GenT.value = doc.data().Gender;
                    }
                    else {
                        console.log(""doc does not exist"");
                    }
                })
                .cath(function (error) {
                    console.log(""error"", error);
                })
        }

        //**********************Button Events*****************************

        document.getElementById('insertBtn').onclick = function () {
            Add_Doc_WithID();

        }

        document.getElementById('selectBtn').onclick = function () {

        }

        document.getElementById('updateBtn').onclick = function () {
            Update_Fields_inDocument();
        }

        document.getElementById('deleteBtn').onclick = function () {
            DeleteDocument();
        }
    </script>


");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Project\MY\New folder\DemoTickit\DemoTickit\Views\Ticket\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "201d2c3b8673f8e2dcd27f2b162ef2977b8b5bc6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ticket_Index), @"mvc.1.0.view", @"/Views/Ticket/Index.cshtml")]
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
#line 1 "C:\Project\MY\New folder\DemoTickit\DemoTickit\Views\_ViewImports.cshtml"
using DemoTicket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Project\MY\New folder\DemoTickit\DemoTickit\Views\_ViewImports.cshtml"
using DemoTicket.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"201d2c3b8673f8e2dcd27f2b162ef2977b8b5bc6", @"/Views/Ticket/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3bc00b28b06fed232eb6dd89bda31bb44107fcd", @"/Views/_ViewImports.cshtml")]
    public class Views_Ticket_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DemoTicket.DTO.BuyerDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Project\MY\New folder\DemoTickit\DemoTickit\Views\Ticket\Index.cshtml"
  
    ViewData["Title"] = "Tickit Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h3>Book ticket</h3>
<div id=""clockdiv"">
    <div>
        <label>You have left: </label>
        <span class=""days"" id=""day""></span>
        <label class=""smalltext"">Days</label>

        <span class=""hours"" id=""hour""></span>
        <label class=""smalltext"">Hours</label>

        <span class=""minutes"" id=""minute""></span>
        <label class=""smalltext"">Minutes</label>

        <span class=""seconds"" id=""second""></span>
        <label class=""smalltext"">Seconds</label>
    </div>
</div>
<div id=""Message""></div>
<div id=""divSuccess""></div>
<div class=""form-group"">
    <label>Buyer Name</label>
    ");
#nullable restore
#line 27 "C:\Project\MY\New folder\DemoTickit\DemoTickit\Views\Ticket\Index.cshtml"
Write(Html.TextBoxFor(model => model.BuyerName, new { @class = "from-control",@required=""}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 28 "C:\Project\MY\New folder\DemoTickit\DemoTickit\Views\Ticket\Index.cshtml"
Write(Html.HiddenFor(model => model.Event.EventId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
#nullable restore
#line 29 "C:\Project\MY\New folder\DemoTickit\DemoTickit\Views\Ticket\Index.cshtml"
Write(Html.HiddenFor(model => model.Event.TimeoutInSeconds));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <input type=""submit"" style=""margin-left:10px"" id=""btnSubmit"" class=""btn btn-primary"" value=""Buy"" />
</div>
<script>
    var x;
    var eventId;
    var windowTimeout;
    $(document).ready(function () {
        eventId = $('#Event_EventId').val();
        checkTickitAvailable(eventId);
        windowTimeout = window.setInterval(function () {
            checkTickitAvailable(eventId);
},3000);
        var time =  parseInt($('#Event_TimeoutInSeconds').val()) * 1000;
        var dateObj = Date.now();
        var deadline = dateObj + time;
        x = setInterval(function () {
                var now = new Date().getTime();
                var t = deadline - now;
                if (t < 0) {
                    clearInterval(x);
                    $('#clockdiv').hide();
                    $('#btnSubmit').hide();
                    document.getElementById(""Message"").innerHTML = ""Time Expire"";
                }
                else {

                var days = Math.floor(t / (100");
            WriteLiteral(@"0 * 60 * 60 * 24));
                var hours = Math.floor((t % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                var minutes = Math.floor((t % (1000 * 60 * 60)) / (1000 * 60));
                var seconds = Math.floor((t % (1000 * 60)) / 1000);
                document.getElementById(""day"").innerHTML = days;
                document.getElementById(""hour"").innerHTML = hours;
                document.getElementById(""minute"").innerHTML = minutes;
                document.getElementById(""second"").innerHTML = seconds;
            }

        }, 1000);
    });
    function checkTickitAvailable(eventId) {
        $.ajax({
            type: 'post',
            url: '");
#nullable restore
#line 71 "C:\Project\MY\New folder\DemoTickit\DemoTickit\Views\Ticket\Index.cshtml"
             Write(Url.ActionLink("CheckTickitAvailability","Ticket"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            dataType: 'json',
            data: { eventId: eventId},
            success: function (result) {
                if (result) {
                    $('#btnSubmit').hide();
                     clearInterval(x);

                    $('#btnSubmit').hide();
                    $('#clockdiv').hide();
                    document.getElementById(""Message"").innerHTML = ""Too Late."";
                }
            }
        })
    }

    $('#btnSubmit').click(function () {
        if ($('#BuyerName').val()=="""") {
            alert(""Please enter buyer name"")
            $('#BuyerName').focus();
            return false;
        }
        $.ajax({
            type: 'post',
            url: '");
#nullable restore
#line 95 "C:\Project\MY\New folder\DemoTickit\DemoTickit\Views\Ticket\Index.cshtml"
             Write(Url.ActionLink("SaveBuyTckit","Ticket"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            dataType: 'json',
            data: { buyerName: $('#BuyerName').val(), eventId: $('#Event_EventId').val() },
            success: function (result) {
                if (result.success) {
                    clearInterval(windowTimeout);
                    clearInterval(x);
                    $('#Message').hide();
                    $('#clockdiv').hide();
                    $('#btnSubmit').hide();
                    document.getElementById(""divSuccess"").innerHTML = ""Congratulation you bought ticket successfully."";
                }
                else {
                     clearInterval(windowTimeout);
                    clearInterval(x);
                    $('#clockdiv').hide();
                    $('#btnSubmit').hide();
                    document.getElementById(""Message"").innerHTML = result.data;
                }
            }
        })
    })
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DemoTicket.DTO.BuyerDto> Html { get; private set; }
    }
}
#pragma warning restore 1591

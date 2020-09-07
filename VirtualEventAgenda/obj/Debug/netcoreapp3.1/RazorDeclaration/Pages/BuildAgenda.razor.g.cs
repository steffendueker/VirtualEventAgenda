#pragma checksum "C:\Users\niophey\repos\VirtualEventAgenda\VirtualEventAgenda\Pages\BuildAgenda.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f606dfbdde026d67acb302efc8be7a3840fbfa4"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace VirtualEventAgenda.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\niophey\repos\VirtualEventAgenda\VirtualEventAgenda\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\niophey\repos\VirtualEventAgenda\VirtualEventAgenda\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\niophey\repos\VirtualEventAgenda\VirtualEventAgenda\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\niophey\repos\VirtualEventAgenda\VirtualEventAgenda\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\niophey\repos\VirtualEventAgenda\VirtualEventAgenda\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\niophey\repos\VirtualEventAgenda\VirtualEventAgenda\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\niophey\repos\VirtualEventAgenda\VirtualEventAgenda\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\niophey\repos\VirtualEventAgenda\VirtualEventAgenda\_Imports.razor"
using VirtualEventAgenda;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\niophey\repos\VirtualEventAgenda\VirtualEventAgenda\_Imports.razor"
using VirtualEventAgenda.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\niophey\repos\VirtualEventAgenda\VirtualEventAgenda\Pages\BuildAgenda.razor"
using VirtualEventAgenda.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\niophey\repos\VirtualEventAgenda\VirtualEventAgenda\Pages\BuildAgenda.razor"
using VirtualEventAgenda.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\niophey\repos\VirtualEventAgenda\VirtualEventAgenda\Pages\BuildAgenda.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/BuildAgenda")]
    public partial class BuildAgenda : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 94 "C:\Users\niophey\repos\VirtualEventAgenda\VirtualEventAgenda\Pages\BuildAgenda.razor"
       
    private List<AgendaTopic> AgendaTopics;
    AgendaTopic selectedAgendaTopic;
    string selectedAgendaTopicID;
    bool showDialog = false;
    int maxID = 0;
    int? maxOrderID = 0;

    // TODO Check - correct ?
    protected override void OnInitialized()
    {
        AgendaTopics = AgendaTopicsService.GetAgendaTopics().ToList();
        maxID = AgendaTopics.Max(i => i.Id);
        maxOrderID = AgendaTopics.Max(i => i.OrderId);
    }

    private void HandleSubmit()
    {
        AgendaTopicsService.SaveAgendaTopicsAsync(AgendaTopics.ToArray()).Wait();
    }



    void SelectAgendaTopic(string AgendaTopicID)
    {
        selectedAgendaTopicID = AgendaTopicID;
        selectedAgendaTopic = AgendaTopicsService.GetAgendaTopics().First(x => x.Id.ToString() == AgendaTopicID);
        showDialog = true;
    }

    void DialogCancel() => showDialog = false;

    void DialogSave()
    {
        AgendaTopicsService.SaveAgendaTopicsAsync(AgendaTopics.ToArray()).Wait();
        showDialog = false;
    }

    void NewAgendaTopic()
    {
        AgendaTopic newEntry = new AgendaTopic();
        newEntry.Id = maxID + 1;
        newEntry.OrderId = maxOrderID + 1;
        AgendaTopics.Add(newEntry);
        this.DialogSave();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private JsonFileAgendaTopicService AgendaTopicsService { get; set; }
    }
}
#pragma warning restore 1591

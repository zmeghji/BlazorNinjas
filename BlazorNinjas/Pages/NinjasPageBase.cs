using ApiModels;
using BlazorNinjas.ApiServices;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorNinjas.Pages
{
    public class NinjasPageBase : ComponentBase
    {
        [Inject]
        public INinjaApiService NinjaApiService { get; set; }
        public List<NinjaApiModel> Ninjas { get; set; } = new List<NinjaApiModel>();
        protected override async Task OnInitializedAsync()
        {
            Ninjas = await NinjaApiService.Get();
            await base.OnInitializedAsync();   
        }
    }
}

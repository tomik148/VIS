﻿using DesctopClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesctopClient.ViewModels
{
    class ListOfOrdersViewModel : BaseViewModel
    {
        public Order[] Orders { get; set; }

        public ListOfOrdersViewModel()
        {
        }

        public override async Task OnOpen()
        {
            Orders = await new Order().GetAllAsync();
        }
    }
}

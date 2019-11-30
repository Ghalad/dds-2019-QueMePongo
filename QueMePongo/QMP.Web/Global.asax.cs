﻿using Ar.UTN.QMP.Lib.Entidades.Core;
using System;
using System.Timers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace QMP.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static Timer ColaPedidosTimer = new Timer(2500);
        private static Timer SchedulerTimer = new Timer(2500);

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            /*
            ColaPedidosTimer.Enabled = true;
            ColaPedidosTimer.Elapsed += new ElapsedEventHandler(ColaPedidosJob);

            SchedulerTimer.Enabled = true;
            SchedulerTimer.Elapsed += new ElapsedEventHandler(SchedulerJob);
            */
        }

        protected void Application_End()
        {
            /*
            ColaPedidosTimer.Stop();
            SchedulerTimer.Stop();
            */
        }





        protected static void ColaPedidosJob(object sender, ElapsedEventArgs e)
        {
            try
            {
                ColaPedidos.GetInstance().DesencolarPedido();
            }
            catch (Exception)
            {
                // Log Exception
            }
        }


        protected static void SchedulerJob(object sender, ElapsedEventArgs e)
        {
            try
            {
                Scheduler.GetInstance().DesencolarPedido();
            }
            catch (Exception)
            {
                // Log Exception
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Mdk.Domain;
using Mdk.Infrastructure;

namespace Mdk.DependencyResolution
{
    // This is the class that connects the interfaces to their implementations.  It is written 
    //  according to the documentation on Autofac's website.  Autofac is merely one of many DI
    //  containers that could have done the job.  I just like the syntax used.  It makes sense 
    //  to me.  
    public static class Initializer
    {
        public static ContainerBuilder Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DataStore>().As<IDataStore>();
            builder.RegisterType<CandidateService>().As<ICandidateService>();
            return builder;
         }
    }
}

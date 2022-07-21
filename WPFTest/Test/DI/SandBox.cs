using Autofac;
using Autofac.Features.OwnedInstances;
using System;
using System.Collections.Generic;
using System.Linq;
using WPFTest.Test.DI.Design;
using WPFTest.Test.DI.Implementation;
using WPFTest.Test.DI.Interface;
using WPFTest.Test.DI.Utility;

namespace WPFTest.Test.DI.Interface
{
    interface IGrandFather
    {
        IList<IFather> Children { get; }
        void CreateChildren();
    }
    interface IFather 
    {
        IList<ISon> Children { get; }
    }
    interface ISon { }

    interface INameService 
    {
        string GetName(object target);
    }
    interface ILogger
    {
        void Log(string msg);
    }
}
namespace WPFTest.Test.DI.Implementation
{
    class GrandFather : IGrandFather
    {
        Func<IFather> _fatherFactory;

        public GrandFather(Func<IFather> fatheractory)
        {
            _fatherFactory = fatheractory;

        }

        public IList<IFather> Children { get; private set; }

        public void CreateChildren()
        {
            var children = Enumerable.Range(0, 5).Select(_ =>
            {
                var f = _fatherFactory();
                return f;
            }).ToArray();

            Children = children;
        }
    }

}
namespace WPFTest.Test.DI.Design
{
    class FakeFather : IFather, IDisposable
    {
        ILogger _logger;

        public IList<ISon> Children => throw new NotImplementedException();

        public void Dispose()
        {
            
        }
    }
}
namespace WPFTest.Test.DI.Utility
{
    class NameService : INameService
    {
        int _count = 0;
        Dictionary<object, int> _map = new();

        public string GetName(object target)
        {
            if (_map.TryGetValue(target, out var result)) 
            {
                
            }
            else
            {
                result = _count;
                _map.Add(target, result);
                _count ++;
            }

            return $"{result}";

        }
    }
}
namespace WPFTest.Test.DI
{
    class User 
    {
        public void Run() 
        {
            //var g = Locator.GrandFather;
            var ownedG = Locator.OwnedGrandFather;
            var serv = Locator.NameService;

            var g = ownedG.Value;

            g.CreateChildren();

            var k = 1;
            g.CreateChildren();

            for (;;) 
            {
                
            }
        }
    }
    class Locator
    {
        static IContainer _container;
        static Locator() 
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterType<GrandFather>()
                .As<IGrandFather>()
                ;
            builder
                .RegisterType<FakeFather>()
                .As<IFather>()
                //.SingleInstance()
                ;

            builder
                .RegisterType<NameService>()
                .As<INameService>()
                ;
            _container = builder.Build();
        }
        public static Owned<IGrandFather> OwnedGrandFather => _container
            .Resolve<Owned<IGrandFather>>()
            ;
        //public static IGrandFather GrandFather => _container
        //    .Resolve<IGrandFather>()
        //    ;
        public static INameService NameService => _container.Resolve<INameService>();
    }
}

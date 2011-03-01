﻿using System.Configuration.Internal;
using System;

namespace NConfig
{
    internal class NConfigSystem : IConfigSystem
    {
        private readonly IConfigSystem baseConfigSystem;
        private readonly NConfigRoot decoratedRoot;
        private readonly INConfiguration configuration;

        public NConfigSystem(IConfigSystem baseConfigSystem, INConfiguration configuration)
        {
            this.baseConfigSystem = baseConfigSystem;
            this.configuration = configuration;
            decoratedRoot = new NConfigRoot(baseConfigSystem.Root, configuration);
        }


        #region IConfigSystem Members

        public IInternalConfigHost Host
        {
            get {
                return baseConfigSystem.Host;
            }
        }

        public void Init(Type typeConfigHost, params object[] hostInitParams)
        {
            baseConfigSystem.Init(typeConfigHost, hostInitParams);
        }

        public IInternalConfigRoot Root
        {
            get {
                return decoratedRoot;    
            }
        }

        #endregion
    }

}
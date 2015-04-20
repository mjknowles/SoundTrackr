// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace SoundTrackr.Web.DependencyResolution {
    using SoundTrackr.Common.Domain;
    using SoundTrackr.Common.UnitOfWork;
    using SoundTrackr.Domain.Entities.Track;
    using SoundTrackr.Repository.Repositories;
    using SoundTrackr.Service.Track;
    using StructureMap;
	
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.AssemblyContainingType<ITrackRepository>();
                    scan.AssemblyContainingType<TrackRepository>();
                    scan.AssemblyContainingType<ITrackService>();
                    scan.AssemblyContainingType<IAggregateRoot>();
                    scan.WithDefaultConventions();
                });
                x.For<IUnitOfWork>().Use<SoundTrackr.Repository.EfUnitOfWork>();
            });
            return ObjectFactory.Container;
        }
    }
}
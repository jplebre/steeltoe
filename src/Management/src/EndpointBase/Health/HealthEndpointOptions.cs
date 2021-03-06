﻿// Copyright 2017 the original author or authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.Extensions.Configuration;
using Steeltoe.Management.Endpoint.Security;
using System.Security.Claims;

namespace Steeltoe.Management.Endpoint.Health
{
    public class HealthEndpointOptions : AbstractEndpointOptions, IHealthOptions
    {
        private const string MANAGEMENT_INFO_PREFIX = "management:endpoints:health";

        public HealthEndpointOptions()
            : base()
        {
            Id = "health";
            RequiredPermissions = Permissions.RESTRICTED;
        }

        public HealthEndpointOptions(IConfiguration config)
            : base(MANAGEMENT_INFO_PREFIX, config)
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = "health";
            }

            if (RequiredPermissions == Permissions.UNDEFINED)
            {
                RequiredPermissions = Permissions.RESTRICTED;
            }

            if (Claim == null && !string.IsNullOrEmpty(Role))
            {
                Claim = new EndpointClaim
                {
                    Type = ClaimTypes.Role,
                    Value = Role
                };
            }
        }

        public ShowDetails ShowDetails { get; set; }

        public EndpointClaim Claim { get; set; }

        public string Role { get; set; }
    }
}

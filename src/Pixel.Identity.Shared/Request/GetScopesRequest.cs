﻿using System.Runtime.Serialization;

namespace Pixel.Identity.Shared.Request
{
    [DataContract]
    public class GetScopesRequest : PagedDataRequest
    {
       public string ScopesFilter { get; set; } = string.Empty;
    }
}

// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Management.Compute
{
    /// <summary>
    /// The Service Management API includes operations for managing the virtual
    /// machine templates in your subscription.
    /// </summary>
    internal partial class VirtualMachineVMImageOperations : IServiceOperations<ComputeManagementClient>, Microsoft.WindowsAzure.Management.Compute.IVirtualMachineVMImageOperations
    {
        /// <summary>
        /// Initializes a new instance of the VirtualMachineVMImageOperations
        /// class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal VirtualMachineVMImageOperations(ComputeManagementClient client)
        {
            this._client = client;
        }
        
        private ComputeManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.WindowsAzure.Management.Compute.ComputeManagementClient.
        /// </summary>
        public ComputeManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// The Begin Deleting Virtual Machine Image operation deletes the
        /// specified virtual machine image.
        /// </summary>
        /// <param name='vmImageName'>
        /// Required. The name of the virtual machine image to delete.
        /// </param>
        /// <param name='deleteFromStorage'>
        /// Required. Specifies that the source blob for the image should also
        /// be deleted from storage.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public async System.Threading.Tasks.Task<OperationResponse> BeginDeletingAsync(string vmImageName, bool deleteFromStorage, CancellationToken cancellationToken)
        {
            // Validate
            if (vmImageName == null)
            {
                throw new ArgumentNullException("vmImageName");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("vmImageName", vmImageName);
                tracingParameters.Add("deleteFromStorage", deleteFromStorage);
                Tracing.Enter(invocationId, this, "BeginDeletingAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            string url = "/" + (this.Client.Credentials.SubscriptionId != null ? this.Client.Credentials.SubscriptionId.Trim() : "") + "/services/vmimages/" + vmImageName.Trim() + "?";
            if (deleteFromStorage == true)
            {
                url = url + "comp=media";
            }
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Delete;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2014-04-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.Accepted)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    OperationResponse result = null;
                    result = new OperationResponse();
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// The Delete Virtual Machine Image operation deletes the specified
        /// virtual machine image.
        /// </summary>
        /// <param name='vmImageName'>
        /// Required. The name of the virtual machine image to delete.
        /// </param>
        /// <param name='deleteFromStorage'>
        /// Required. Specifies that the source blob for the image should also
        /// be deleted from storage.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself. If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request. If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request and error information regarding
        /// the failure.
        /// </returns>
        public async System.Threading.Tasks.Task<OperationStatusResponse> DeleteAsync(string vmImageName, bool deleteFromStorage, CancellationToken cancellationToken)
        {
            ComputeManagementClient client = this.Client;
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("vmImageName", vmImageName);
                tracingParameters.Add("deleteFromStorage", deleteFromStorage);
                Tracing.Enter(invocationId, this, "DeleteAsync", tracingParameters);
            }
            try
            {
                if (shouldTrace)
                {
                    client = this.Client.WithHandler(new ClientRequestTrackingHandler(invocationId));
                }
                
                cancellationToken.ThrowIfCancellationRequested();
                OperationResponse response = await client.VirtualMachineVMImages.BeginDeletingAsync(vmImageName, deleteFromStorage, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                OperationStatusResponse result = await client.GetOperationStatusAsync(response.RequestId, cancellationToken).ConfigureAwait(false);
                int delayInSeconds = 30;
                while ((result.Status != OperationStatus.InProgress) == false)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await TaskEx.Delay(delayInSeconds * 1000, cancellationToken).ConfigureAwait(false);
                    cancellationToken.ThrowIfCancellationRequested();
                    result = await client.GetOperationStatusAsync(response.RequestId, cancellationToken).ConfigureAwait(false);
                    delayInSeconds = 30;
                }
                
                if (shouldTrace)
                {
                    Tracing.Exit(invocationId, result);
                }
                
                if (result.Status != OperationStatus.Succeeded)
                {
                    if (result.Error != null)
                    {
                        CloudException ex = new CloudException(result.Error.Code + " : " + result.Error.Message);
                        ex.ErrorCode = result.Error.Code;
                        ex.ErrorMessage = result.Error.Message;
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    else
                    {
                        CloudException ex = new CloudException("");
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                }
                
                return result;
            }
            finally
            {
                if (client != null && shouldTrace)
                {
                    client.Dispose();
                }
            }
        }
        
        /// <summary>
        /// The List Virtual Machine Images operation retrieves a list of the
        /// virtual machine images.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List VM Images operation response.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.Compute.Models.VirtualMachineVMImageListResponse> ListAsync(CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                Tracing.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            string url = "/" + (this.Client.Credentials.SubscriptionId != null ? this.Client.Credentials.SubscriptionId.Trim() : "") + "/services/vmimages";
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2014-04-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    VirtualMachineVMImageListResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new VirtualMachineVMImageListResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement vMImagesSequenceElement = responseDoc.Element(XName.Get("VMImages", "http://schemas.microsoft.com/windowsazure"));
                    if (vMImagesSequenceElement != null)
                    {
                        foreach (XElement vMImagesElement in vMImagesSequenceElement.Elements(XName.Get("VMImage", "http://schemas.microsoft.com/windowsazure")))
                        {
                            VirtualMachineVMImageListResponse.VirtualMachineVMImage vMImageInstance = new VirtualMachineVMImageListResponse.VirtualMachineVMImage();
                            result.VMImages.Add(vMImageInstance);
                            
                            XElement nameElement = vMImagesElement.Element(XName.Get("Name", "http://schemas.microsoft.com/windowsazure"));
                            if (nameElement != null)
                            {
                                string nameInstance = nameElement.Value;
                                vMImageInstance.Name = nameInstance;
                            }
                            
                            XElement labelElement = vMImagesElement.Element(XName.Get("Label", "http://schemas.microsoft.com/windowsazure"));
                            if (labelElement != null)
                            {
                                string labelInstance = labelElement.Value;
                                vMImageInstance.Label = labelInstance;
                            }
                            
                            XElement categoryElement = vMImagesElement.Element(XName.Get("Category", "http://schemas.microsoft.com/windowsazure"));
                            if (categoryElement != null)
                            {
                                string categoryInstance = categoryElement.Value;
                                vMImageInstance.Category = categoryInstance;
                            }
                            
                            XElement oSDiskConfigurationElement = vMImagesElement.Element(XName.Get("OSDiskConfiguration", "http://schemas.microsoft.com/windowsazure"));
                            if (oSDiskConfigurationElement != null)
                            {
                                VirtualMachineVMImageListResponse.OSDiskConfiguration oSDiskConfigurationInstance = new VirtualMachineVMImageListResponse.OSDiskConfiguration();
                                vMImageInstance.OSDiskConfiguration = oSDiskConfigurationInstance;
                                
                                XElement nameElement2 = oSDiskConfigurationElement.Element(XName.Get("Name", "http://schemas.microsoft.com/windowsazure"));
                                if (nameElement2 != null)
                                {
                                    string nameInstance2 = nameElement2.Value;
                                    oSDiskConfigurationInstance.Name = nameInstance2;
                                }
                                
                                XElement hostCachingElement = oSDiskConfigurationElement.Element(XName.Get("HostCaching", "http://schemas.microsoft.com/windowsazure"));
                                if (hostCachingElement != null && string.IsNullOrEmpty(hostCachingElement.Value) == false)
                                {
                                    VirtualHardDiskHostCaching hostCachingInstance = ((VirtualHardDiskHostCaching)Enum.Parse(typeof(VirtualHardDiskHostCaching), hostCachingElement.Value, true));
                                    oSDiskConfigurationInstance.HostCaching = hostCachingInstance;
                                }
                                
                                XElement oSStateElement = oSDiskConfigurationElement.Element(XName.Get("OSState", "http://schemas.microsoft.com/windowsazure"));
                                if (oSStateElement != null)
                                {
                                    string oSStateInstance = oSStateElement.Value;
                                    oSDiskConfigurationInstance.OSState = oSStateInstance;
                                }
                                
                                XElement osElement = oSDiskConfigurationElement.Element(XName.Get("OS", "http://schemas.microsoft.com/windowsazure"));
                                if (osElement != null)
                                {
                                    string osInstance = osElement.Value;
                                    oSDiskConfigurationInstance.OperatingSystem = osInstance;
                                }
                                
                                XElement mediaLinkElement = oSDiskConfigurationElement.Element(XName.Get("MediaLink", "http://schemas.microsoft.com/windowsazure"));
                                if (mediaLinkElement != null)
                                {
                                    Uri mediaLinkInstance = TypeConversion.TryParseUri(mediaLinkElement.Value);
                                    oSDiskConfigurationInstance.MediaLink = mediaLinkInstance;
                                }
                                
                                XElement logicalDiskSizeInGBElement = oSDiskConfigurationElement.Element(XName.Get("LogicalDiskSizeInGB", "http://schemas.microsoft.com/windowsazure"));
                                if (logicalDiskSizeInGBElement != null)
                                {
                                    int logicalDiskSizeInGBInstance = int.Parse(logicalDiskSizeInGBElement.Value, CultureInfo.InvariantCulture);
                                    oSDiskConfigurationInstance.LogicalDiskSizeInGB = logicalDiskSizeInGBInstance;
                                }
                            }
                            
                            XElement dataDiskConfigurationsSequenceElement = vMImagesElement.Element(XName.Get("DataDiskConfigurations", "http://schemas.microsoft.com/windowsazure"));
                            if (dataDiskConfigurationsSequenceElement != null)
                            {
                                foreach (XElement dataDiskConfigurationsElement in dataDiskConfigurationsSequenceElement.Elements(XName.Get("DataDiskConfiguration", "http://schemas.microsoft.com/windowsazure")))
                                {
                                    VirtualMachineVMImageListResponse.DataDiskConfiguration dataDiskConfigurationInstance = new VirtualMachineVMImageListResponse.DataDiskConfiguration();
                                    vMImageInstance.DataDiskConfigurations.Add(dataDiskConfigurationInstance);
                                    
                                    XElement nameElement3 = dataDiskConfigurationsElement.Element(XName.Get("Name", "http://schemas.microsoft.com/windowsazure"));
                                    if (nameElement3 != null)
                                    {
                                        string nameInstance3 = nameElement3.Value;
                                        dataDiskConfigurationInstance.Name = nameInstance3;
                                    }
                                    
                                    XElement hostCachingElement2 = dataDiskConfigurationsElement.Element(XName.Get("HostCaching", "http://schemas.microsoft.com/windowsazure"));
                                    if (hostCachingElement2 != null && string.IsNullOrEmpty(hostCachingElement2.Value) == false)
                                    {
                                        VirtualHardDiskHostCaching hostCachingInstance2 = ((VirtualHardDiskHostCaching)Enum.Parse(typeof(VirtualHardDiskHostCaching), hostCachingElement2.Value, true));
                                        dataDiskConfigurationInstance.HostCaching = hostCachingInstance2;
                                    }
                                    
                                    XElement lunElement = dataDiskConfigurationsElement.Element(XName.Get("Lun", "http://schemas.microsoft.com/windowsazure"));
                                    if (lunElement != null && string.IsNullOrEmpty(lunElement.Value) == false)
                                    {
                                        int lunInstance = int.Parse(lunElement.Value, CultureInfo.InvariantCulture);
                                        dataDiskConfigurationInstance.LogicalUnitNumber = lunInstance;
                                    }
                                    
                                    XElement mediaLinkElement2 = dataDiskConfigurationsElement.Element(XName.Get("MediaLink", "http://schemas.microsoft.com/windowsazure"));
                                    if (mediaLinkElement2 != null)
                                    {
                                        Uri mediaLinkInstance2 = TypeConversion.TryParseUri(mediaLinkElement2.Value);
                                        dataDiskConfigurationInstance.MediaLink = mediaLinkInstance2;
                                    }
                                    
                                    XElement logicalDiskSizeInGBElement2 = dataDiskConfigurationsElement.Element(XName.Get("LogicalDiskSizeInGB", "http://schemas.microsoft.com/windowsazure"));
                                    if (logicalDiskSizeInGBElement2 != null)
                                    {
                                        int logicalDiskSizeInGBInstance2 = int.Parse(logicalDiskSizeInGBElement2.Value, CultureInfo.InvariantCulture);
                                        dataDiskConfigurationInstance.LogicalDiskSizeInGB = logicalDiskSizeInGBInstance2;
                                    }
                                }
                            }
                            
                            XElement serviceNameElement = vMImagesElement.Element(XName.Get("ServiceName", "http://schemas.microsoft.com/windowsazure"));
                            if (serviceNameElement != null)
                            {
                                string serviceNameInstance = serviceNameElement.Value;
                                vMImageInstance.ServiceName = serviceNameInstance;
                            }
                            
                            XElement deploymentNameElement = vMImagesElement.Element(XName.Get("DeploymentName", "http://schemas.microsoft.com/windowsazure"));
                            if (deploymentNameElement != null)
                            {
                                string deploymentNameInstance = deploymentNameElement.Value;
                                vMImageInstance.DeploymentName = deploymentNameInstance;
                            }
                            
                            XElement roleNameElement = vMImagesElement.Element(XName.Get("RoleName", "http://schemas.microsoft.com/windowsazure"));
                            if (roleNameElement != null)
                            {
                                string roleNameInstance = roleNameElement.Value;
                                vMImageInstance.RoleName = roleNameInstance;
                            }
                            
                            XElement affinityGroupElement = vMImagesElement.Element(XName.Get("AffinityGroup", "http://schemas.microsoft.com/windowsazure"));
                            if (affinityGroupElement != null)
                            {
                                string affinityGroupInstance = affinityGroupElement.Value;
                                vMImageInstance.AffinityGroup = affinityGroupInstance;
                            }
                            
                            XElement createdTimeElement = vMImagesElement.Element(XName.Get("CreatedTime", "http://schemas.microsoft.com/windowsazure"));
                            if (createdTimeElement != null && string.IsNullOrEmpty(createdTimeElement.Value) == false)
                            {
                                DateTime createdTimeInstance = DateTime.Parse(createdTimeElement.Value, CultureInfo.InvariantCulture);
                                vMImageInstance.CreatedTime = createdTimeInstance;
                            }
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}

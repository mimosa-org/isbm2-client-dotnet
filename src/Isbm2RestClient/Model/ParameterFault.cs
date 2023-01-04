/*
 * ISBM 2.0
 *
 * An OpenAPI specification for the ISBM 2.0 RESTful interface.
 *
 * The version of the OpenAPI document: 2.0.1
 * Contact: info@mimosa.org
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Isbm2RestClient.Client.OpenAPIDateConverter;

namespace Isbm2RestClient.Model
{
    /// <summary>
    /// Returned when any given parameter is malformed or not optional but blank. The HTTP response status must be 400.
    /// </summary>
    [DataContract(Name = "ParameterFault")]
    public partial class ParameterFault : IEquatable<ParameterFault>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterFault" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ParameterFault()
        {
            this.AdditionalProperties = new Dictionary<string, object>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterFault" /> class.
        /// </summary>
        /// <param name="fault">Human readable explanation of the error. (required).</param>
        public ParameterFault(string fault = default(string))
        {
            // to ensure "fault" is required (not null)
            if (fault == null)
            {
                throw new ArgumentNullException("fault is a required property for ParameterFault and cannot be null");
            }
            this.Fault = fault;
            this.AdditionalProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Human readable explanation of the error.
        /// </summary>
        /// <value>Human readable explanation of the error.</value>
        [DataMember(Name = "fault", IsRequired = true)]
        public string Fault { get; set; }

        /// <summary>
        /// Gets or Sets additional properties
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ParameterFault {\n");
            sb.Append("  Fault: ").Append(Fault).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ParameterFault);
        }

        /// <summary>
        /// Returns true if ParameterFault instances are equal
        /// </summary>
        /// <param name="input">Instance of ParameterFault to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ParameterFault input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Fault == input.Fault ||
                    (this.Fault != null &&
                    this.Fault.Equals(input.Fault))
                )
                && (this.AdditionalProperties.Count == input.AdditionalProperties.Count && !this.AdditionalProperties.Except(input.AdditionalProperties).Any());
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Fault != null)
                {
                    hashCode = (hashCode * 59) + this.Fault.GetHashCode();
                }
                if (this.AdditionalProperties != null)
                {
                    hashCode = (hashCode * 59) + this.AdditionalProperties.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}

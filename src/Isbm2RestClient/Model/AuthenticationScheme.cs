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
    /// AuthenticationScheme
    /// </summary>
    [DataContract(Name = "AuthenticationScheme")]
    public partial class AuthenticationScheme : IEquatable<AuthenticationScheme>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationScheme" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AuthenticationScheme()
        {
            this.AdditionalProperties = new Dictionary<string, object>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationScheme" /> class.
        /// </summary>
        /// <param name="schemeName">schemeName (required).</param>
        /// <param name="schemeInfoUrl">schemeInfoUrl.</param>
        public AuthenticationScheme(string schemeName = default(string), string schemeInfoUrl = default(string))
        {
            // to ensure "schemeName" is required (not null)
            if (schemeName == null)
            {
                throw new ArgumentNullException("schemeName is a required property for AuthenticationScheme and cannot be null");
            }
            this.SchemeName = schemeName;
            this.SchemeInfoUrl = schemeInfoUrl;
            this.AdditionalProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or Sets SchemeName
        /// </summary>
        [DataMember(Name = "schemeName", IsRequired = true)]
        public string SchemeName { get; set; }

        /// <summary>
        /// Gets or Sets SchemeInfoUrl
        /// </summary>
        [DataMember(Name = "schemeInfoUrl", EmitDefaultValue = false)]
        public string SchemeInfoUrl { get; set; }

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
            sb.Append("class AuthenticationScheme {\n");
            sb.Append("  SchemeName: ").Append(SchemeName).Append("\n");
            sb.Append("  SchemeInfoUrl: ").Append(SchemeInfoUrl).Append("\n");
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
            return this.Equals(input as AuthenticationScheme);
        }

        /// <summary>
        /// Returns true if AuthenticationScheme instances are equal
        /// </summary>
        /// <param name="input">Instance of AuthenticationScheme to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AuthenticationScheme input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.SchemeName == input.SchemeName ||
                    (this.SchemeName != null &&
                    this.SchemeName.Equals(input.SchemeName))
                ) && 
                (
                    this.SchemeInfoUrl == input.SchemeInfoUrl ||
                    (this.SchemeInfoUrl != null &&
                    this.SchemeInfoUrl.Equals(input.SchemeInfoUrl))
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
                if (this.SchemeName != null)
                {
                    hashCode = (hashCode * 59) + this.SchemeName.GetHashCode();
                }
                if (this.SchemeInfoUrl != null)
                {
                    hashCode = (hashCode * 59) + this.SchemeInfoUrl.GetHashCode();
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

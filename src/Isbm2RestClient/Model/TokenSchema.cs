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
    /// TokenSchema
    /// </summary>
    [DataContract(Name = "TokenSchema")]
    public partial class TokenSchema : IEquatable<TokenSchema>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenSchema" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected TokenSchema()
        {
            this.AdditionalProperties = new Dictionary<string, object>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenSchema" /> class.
        /// </summary>
        /// <param name="namespaceName">namespaceName (required).</param>
        /// <param name="schemaLocation">schemaLocation.</param>
        public TokenSchema(string namespaceName = default(string), string schemaLocation = default(string))
        {
            // to ensure "namespaceName" is required (not null)
            if (namespaceName == null)
            {
                throw new ArgumentNullException("namespaceName is a required property for TokenSchema and cannot be null");
            }
            this.NamespaceName = namespaceName;
            this.SchemaLocation = schemaLocation;
            this.AdditionalProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or Sets NamespaceName
        /// </summary>
        [DataMember(Name = "namespaceName", IsRequired = true)]
        public string NamespaceName { get; set; }

        /// <summary>
        /// Gets or Sets SchemaLocation
        /// </summary>
        [DataMember(Name = "schemaLocation", EmitDefaultValue = false)]
        public string SchemaLocation { get; set; }

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
            sb.Append("class TokenSchema {\n");
            sb.Append("  NamespaceName: ").Append(NamespaceName).Append("\n");
            sb.Append("  SchemaLocation: ").Append(SchemaLocation).Append("\n");
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
            return this.Equals(input as TokenSchema);
        }

        /// <summary>
        /// Returns true if TokenSchema instances are equal
        /// </summary>
        /// <param name="input">Instance of TokenSchema to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TokenSchema input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.NamespaceName == input.NamespaceName ||
                    (this.NamespaceName != null &&
                    this.NamespaceName.Equals(input.NamespaceName))
                ) && 
                (
                    this.SchemaLocation == input.SchemaLocation ||
                    (this.SchemaLocation != null &&
                    this.SchemaLocation.Equals(input.SchemaLocation))
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
                if (this.NamespaceName != null)
                {
                    hashCode = (hashCode * 59) + this.NamespaceName.GetHashCode();
                }
                if (this.SchemaLocation != null)
                {
                    hashCode = (hashCode * 59) + this.SchemaLocation.GetHashCode();
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

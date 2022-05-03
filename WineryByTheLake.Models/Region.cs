// <copyright file="Region.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Base of every region entity.
    /// </summary>
    [Table("regions")]
    public class Region
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Region"/> class.
        /// </summary>
        public Region()
        {
            this.Suppliers = new HashSet<Supplier>();
        }

        /// <summary>
        /// Gets or sets the ID of a region.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of a region.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets the suppliers which live in the region.
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Supplier> Suppliers { get; }

        /*/// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() != typeof(Region))
                {
                    return false;
                }
                else
                {
                    Region other = obj as Region;
                    return other.Id == this.Id && other.Name == this.Name;
                }
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return (int)(Math.Pow(this.Id, 2) * this.Name.Length);
        }*/

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.Name;
        }
    }
}

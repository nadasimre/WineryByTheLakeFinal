// <copyright file="Supplier.cs" company="PlaceholderCompany">
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
    /// Base of every supplier entity.
    /// </summary>
    [Table("suppliers")]
    public class Supplier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Supplier"/> class.
        /// </summary>
        public Supplier()
        {
            this.Wines = new HashSet<Wine>();
        }

        /// <summary>
        /// Gets or sets the ID of a supplier.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of a supplier.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the sum of every wine a supplier has.
        /// </summary>
        public int WinePriceSum { get; set; }

        /// <summary>
        /// Gets the wines which the supplier has.
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Wine> Wines { get; }

        /// <summary>
        /// Gets or sets the region of a supplier.
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public virtual Region Region { get; set; }

        /// <summary>
        /// Gets or sets the ID of the suppliers region.
        /// </summary>
        [ForeignKey(nameof(Region))]
        public int RegionID { get; set; }

        /*/// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() != typeof(Supplier))
                {
                    return false;
                }
                else
                {
                    Supplier other = obj as Supplier;
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
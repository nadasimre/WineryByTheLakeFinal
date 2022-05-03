// <copyright file="Wine.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Base of every wine entity.
    /// </summary>
    [Table("wines")]
    public class Wine
    {
        /// <summary>
        /// Gets or sets the ID of a wine.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of a wine.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the color of a wine.
        /// </summary>
        public ColorE Color { get; set; }

        /// <summary>
        /// Gets or sets the sweetness of a wine.
        /// </summary>
        public string Sweetness { get; set; }

        /// <summary>
        /// Gets or sets the price of a wine.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Gets or sets the supplier which the wine is from.
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public virtual Supplier Supplier { get; set; }

        /// <summary>
        /// Gets or sets the supplier which the wine is from.
        /// </summary>
        [ForeignKey(nameof(Supplier))]
        public int SupplierID { get; set; }

        /*/// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() != typeof(Wine))
                {
                    return false;
                }
                else
                {
                    Wine other = obj as Wine;
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

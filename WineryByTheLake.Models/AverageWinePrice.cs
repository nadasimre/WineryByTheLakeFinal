// <copyright file="AverageWinePrice.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;

[assembly: CLSCompliant(false)]

namespace WineryByTheLake.Models
{
    /// <summary>
    /// It has all the properties, which are required to describe an average of wine prices.
    /// </summary>
    public class AverageWinePrice
    {
        /// <summary>
        /// Gets or sets the supplier, whose wines we want to average.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the average wine price.
        /// </summary>
        public double Value { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() != typeof(AverageWinePrice))
                {
                    return false;
                }
                else
                {
                    AverageWinePrice another = obj as AverageWinePrice;
                    return another.Name == this.Name && another.Value == this.Value;
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
            return (int)(this.Name.Length * this.Value);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.Name + " - " + this.Value;
        }
    }
}

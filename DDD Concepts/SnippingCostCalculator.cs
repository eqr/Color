// example from Patterns, Principles and Practicies of Domain-Driven Design

using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDConcepts
{
    public class ShippingCostCalculator
    {
        private IEnumerable<WeightBand> _weightBand; private readonly WeightInKg _boxWeightInKg;
        public ShippingCostCalculator(IEnumerable<WeightBand> weightBand, WeightInKg boxWeightInKg)
        {
            _weightBand = weightBand; _boxWeightInKg = boxWeightInKg;
        }
        public Money CalculateCostToShip(IEnumerable<Consignment> consignments)
        {
            var weight = this.GetTotalWeight(consignments);
            // Reverse sort list
            _weightBand = _weightBand.OrderBy(x => x.ForConsignmentsUpToThisWeightInKg.Value);
            // Get first match
            var weightBand = _weightBand.FirstOrDefault(x =>
            x.IsWithinBand(weight));
            return weightBand.Price;
        }
        private WeightInKg GetTotalWeight(IEnumerable<Consignment> consignments)
        {
            var totalWeight = new WeightInKg(0m);
            // Calculate the weight of the items
            foreach (Consignment consignment in consignments)
                totalWeight = totalWeight.Add(consignment.ConsignmentWeight());
            // Add a box weight
            totalWeight = totalWeight.Add(_boxWeightInKg);
            return totalWeight;
        }
    }
}
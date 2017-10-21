namespace DDDConcepts
{
    public class RecommendationsEventHandler
    {
        private IRecommendationService recommendationService;

        public RecommendationsEventHandler(IRecommendationService recommendationService)
        {
            this.recommendationService = recommendationService;
        }

        public void Handle(ProductAddedToBasket event) 
        {
            this.recommendationService.UpdateSuggestionsFor(event.BasketId, event.Items);
        }
    }
}
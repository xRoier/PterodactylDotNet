using Flurl.Util;

public static class Extensions {
    public static IFlurlRequest WithFilters(this IFlurlRequest request, object filters) {
        if (filters is null) return request;

        foreach (var item in filters.ToKeyValuePairs()) {
            request.SetQueryParam($"filter[{item.Key}]", item.Value);
        }
        return request;
    }
}
# ApiAggregator

# Aggregated END POINTS
- /api/nw/[date]/[longitude]/[latitude]/[keyword]
-- Will query for news on a given [date] (YYYY-MM-DD) with a given [keyword] and will aggregate weather information on given [longitude] and [latitude].

- /api/nwc/[DATE]/[CITY]/[keyword]
-- Will query for news on a given [date] (YYYY-MM-DD) with a given [keyword] and will aggregate weather information on given [city].

- /api/nwd/[DATE]/[longitude]/[latitude]/[keyword]
-- Will query for news on a given [date] (YYYY-MM-DD) with a given [keyword] and will aggregate weather information on given [longitude] and [latitude]. Will also provide dictionary information on the [keyword].

- /api/d/[KEYWORD]
-- Will provide dictionary information on the [keyword].

# END POINTS Stats
- https://localhost:44309/stats/all

# END POINTS Stats extra
- https://localhost:44309/stats/total
- https://localhost:44309/stats/averaged
- https://localhost:44309/stats/total_avg

# IO Formats
- All output in json format

# SETUP/CONFIG
1. Config API keys for "News" and "Weather", add in Command line arguments 
- NewsAPI=[API Key]
- WeatherAPI=[API Key]
2. Config for internal cache expiration period for memory manager
- CacheExpirationPeriod=60

# quick API examples
- https://localhost:44309/api/nw/2024-12-27/60/30/Moldavia
- https://localhost:44309/api/nwd/2024-12-27/60/30/cat
- https://localhost:44309/api/nwc/2024-12-29/Paris/dog
- https://localhost:44309/api/d/dog
- https://localhost:44309/stats/total_avg

# TODO
- Use of dependency injection
- Write unit-test
- Rework on output formats
- More documentation on END Points
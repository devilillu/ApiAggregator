# ApiAggregator
- Simply combine together json responses from various external APIs

# Used APIs
- https://api.dictionaryapi.dev
- https://newsapi.org
- https://api.openweathermap.org

# For adding new external API
1. Inherit from "ExternalApiFunctionBase" when creating a new "NewApiFunctionBase"
2. Write new functions for new API by inheriting from "NewApiFunctionBase"

# For creating new aggregated internal API method calls
1. Create new AggregateFunction class by inheriting from AggregateFunctionBase
2. Add new aggregate function on "BuildAggregatedApi" return list

# DOC - END POINTS - Aggregated
- /api/nw/[date]/[longitude]/[latitude]/[keyword]
-- Will query for news on a given [date] (YYYY-MM-DD) with a given [keyword] and will aggregate weather information on given [longitude] and [latitude].

- /api/nwc/[DATE]/[CITY]/[keyword]
-- Will query for news on a given [date] (YYYY-MM-DD) with a given [keyword] and will aggregate weather information on given [city].

- /api/nwd/[DATE]/[longitude]/[latitude]/[keyword]
-- Will query for news on a given [date] (YYYY-MM-DD) with a given [keyword] and will aggregate weather information on given [longitude] and [latitude]. Will also provide dictionary information on the [keyword].

- /api/d/[KEYWORD]
-- Will provide dictionary information on the [keyword].

# DOC - END POINTS - Stats
- https://localhost:44309/stats/total_avg

# DOC - END POINTS - Stats extra
- https://localhost:44309/stats/all
- https://localhost:44309/stats/total
- https://localhost:44309/stats/averaged

# DOC - IO Formats
- All output in json format
- Statistics printed in free text
- < 100ms is Ultra
- < 200ms is Fast
- < 350 is Medium
- < 700 is Slow
- rest are Turtle

# DOC - SETUP/CONFIG
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
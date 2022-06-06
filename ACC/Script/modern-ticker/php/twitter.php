<?php

$settings = array(
	"consumer_key" => "2kV0cy6UhQVc3ZhqVJFIyQ",
	"consumer_secret" => "vWqceM4PBoUJELH5s8bACkJLwo3RvFBU5vdbDqIM",
	"access_token" => "233878017-agu1DtKKpmQGtjVTxXZZ55JaaF6yrd9P4rLrqkxI",
	"access_token_secret" => "k3W6YcUP2XMw517ISDJ9PyBms0CqMfjRVhJXjYlQA"
);


$name = $_GET["name"];
$count = $_GET["count"];

require_once("TwitterAPIExchange.php");

$url = "https://api.twitter.com/1.1/statuses/user_timeline.json";
$getfield = "?screen_name=" . $name . "&count=" . $count . "&trim_user=true";
$method = "GET";
$twitter = new TwitterAPIExchange($settings);

echo $twitter->setGetfield($getfield)
			 ->buildOauth($url, $method)
			 ->performRequest();

?>
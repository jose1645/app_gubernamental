import json
import boto3
from boto3.dynamodb.conditions import Attr

client = boto3.client('dynamodb')
dynamodb = boto3.resource("dynamodb")
table = dynamodb.Table('reportebache')
def lambda_handler(event, context):
    print(event)
    body = {}
    statusCode = 200
    headers = {
        "Content-Type": "application/json"
    }
    try:
          body= table.scan(
            #TableName= "Your-Table-Name",
           ProjectionExpression='id,fecha,latitud,longitud,nombre',
           FilterExpression=Attr('existe').eq(1)
        )
    except KeyError:
        statusCode = 400
        body = 'Unsupported route: ' + event['routeKey']
    body = json.dumps(body)
    res = {
        "statusCode": statusCode,
        "headers": {
            "Content-Type": "application/json"
        },
        "body": body
    }
    return res
    
    
  
   
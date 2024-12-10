import boto3
import json

dynamodb = boto3.resource('dynamodb')
table = dynamodb.Table('reportebache')

def lambda_handler(event, context):
    # Obtener el cuerpo de la solicitud
    body = json.loads(event['body'])

    # Actualizar el ítem en la tabla
    response = table.update_item(
        Key={'id': body['id']},
        UpdateExpression='set #attr = :val',
        ExpressionAttributeNames={'#attr': 'existe'},
        ExpressionAttributeValues={':val': body['existe']}
    )
    
    # Retornar una respuesta HTTP
    return {
        'statusCode': 200,
        'body': json.dumps({'message': 'Ítem actualizado correctamente'})
    }

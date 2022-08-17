## API Kullanımı

#### CRUD işlemlerinde kullandığım property

```http
  GET/GetByid,Put,Post,Delete 
```

| Parametre | Tip     | Açıklama                |
| :-------- | :------- | :------------------------- |
| `id` | `int` | **Gerekli**. id. |
| `Name` | `string` | **Gerekli**. Name. |
| `LastName` | `string` | **Gerekli**. LastName. |
| `Email` | `string` | **Gerekli**. Email. |
| `PhoneNumber` | `int` | **Gerekli**. PhoneNumber. |
| `Salary` | `double` | **Gerekli**. Salary. |

Bu property'ler ile CRUD işlemlerini gerçekleştirdim.

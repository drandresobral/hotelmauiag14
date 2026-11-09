# Hotel Aurora — Agenda 14 (.NET MAUI / C#)

Projeto acadêmico baseado no AppHotel Agenda 13, personalizado para a Agenda 14.

## Novidades
- Identidade visual azul-marinho e turquesa.
- Nova tela inicial com apresentação e catálogo de acomodações.
- Formulário de reserva com seleção de acomodação, limite de hóspedes, validação de datas e prévia de valores.
- Resumo com valor unitário, quantidade de diárias e total.
- Botões para limpar o formulário, editar e concluir a simulação.
- Classes `Acomodacao`, `CatalogoAcomodacoes` (coleção dinâmica `List<T>`) e `Reserva` com encapsulamento e validações.

## Como executar
Abra `AppHotelAgenda13.csproj` no Visual Studio com a carga de trabalho .NET MAUI e SDK .NET 10 instalados. Selecione Windows Machine ou emulador Android e execute.

## Observações
O aplicativo é demonstrativo, não realiza pagamentos, não persiste reservas nem se comunica com hotéis reais. Valores de diárias são ilustrativos. As datas são validadas e a saída deve ocorrer ao menos um dia após a entrada.

## Testes sugeridos
1. Nome vazio → alerta.
2. Alterar suíte → limite de hóspedes e prévia atualizados.
3. Alterar entrada → saída mínima recalculada.
4. Resumo → valor total igual a número de diárias multiplicado pela tarifa.
5. Concluir simulação → mensagem e retorno à tela inicial.

A compilação deve ser validada em uma instalação local do Visual Studio com .NET MAUI.

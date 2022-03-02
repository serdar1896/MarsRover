$(document).ready(function () {

    $("#moveButton").click(function (e) {
        e.preventDefault();
        e.stopPropagation();

        let plateau = {
            Width: 0,
            Height: 0
        };
        var direction = new Array;

        plateau.Width = $("#PlatoX").val();
        plateau.Height = $("#PlatoY").val();

        direction[0] = $("#1MoveDirective").val();
        direction[1] = $("#2MoveDirective").val();

        const position =        
            [
                { "x": $("#1PosX").val(), "y": $("#1PosY").val(), "direction": $("#1PosDirectionOption").val() },
                { "x": $("#2PosX").val(), "y": $("#2PosY").val(), "direction": $("#2PosDirectionOption").val() }
            ];
        
        $.post('Rover/MoveDirectiveForRover', { plateauModel: plateau, positionModels: position, directions: direction },
            function (result, status, xhr) {
                Swal.fire(
                    'Rover Coordinate',
                    JSON.stringify(result),
                    'success'
                )
            },
            'json')
            .fail(function (error) {
                Swal.fire(
                    'Error!',
                    JSON.stringify(error),
                    'error'
                )
            });

        
       


     
  
    });


});



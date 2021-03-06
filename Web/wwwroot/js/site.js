
import {attachValidation, formToObject} from "./helpers.js"


(async () => {
    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/generator")
        .withAutomaticReconnect()
        .build();
    await hubConnection.start();

    let currentProgress = 0;



    const setProgress = progress => {
        $('.progress-bar').css('width', progress + '%').attr('aria-valuenow', progress);
    }

    const createRow = ({ functionText, avalancheEffect }) =>
        $("<tr/>").append($("<td/>", {
            html: $("<pre/>", {
                text: functionText
            })

        })).append($("<td/>", {
            text: avalancheEffect
        }));




    hubConnection.on("bestchanged",
        item => {
            const tableBody = $("#best tbody");
            tableBody.empty();
            tableBody.append(createRow(item));


        });



    hubConnection.on("progress", progress => {
        if (progress > currentProgress) {
            currentProgress = progress;

            setProgress(currentProgress);
        }
    });

    const startStream = config => {
        const allTable = $("#all tbody");
        allTable.empty();
        
        hubConnection.stream("generate", config)
            .subscribe({
                next: item => {
                    console.log(item);

                    const table = $("#all table");

                    table.append(createRow(item));


                },
                complete: () => {
                    const doneModal = $("#doneModal");
                    doneModal.modal("show");
                    setTimeout(() => doneModal.modal("hide"), 4000);
                },
                error: err => {
                    console.log(err);
                    const li = document.createElement("li");
                    li.textContent = err;
                    document.body.appendChild(li);
                }
            });

    }


    const configForm = $("form");

    console.log(configForm);

    
    attachValidation(configForm);

    $(configForm).data("validator").settings.submitHandler =
        (form, event) => {
            event.preventDefault();
            console.log("FFFFFFFFFFFFFFFFFFFFFFFFFF");
            console.log(formToObject($(event.target)));
            startStream(formToObject($(event.target)));
        };
    





})();

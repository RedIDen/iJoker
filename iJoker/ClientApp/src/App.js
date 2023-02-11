import React, { useEffect, useState } from 'react';
import './custom.css';
import LikeButton from "./components/LikeButton";

const App = () => {
    const [jokes, setJokes] = useState([]);

    useEffect(() => {
        fetch("api/jokes")
            .then(response => {
                return response.json();
            })
            .then(responseJson => {
                setJokes(responseJson);
            })
    }, []);

    return (
        <div className="bg-light h-100">
            <div className="border header bg-white sticky-top px-4 py-2 d-flex justify-content-between">
                <h1>
                    iJokes
                </h1>
            </div>
            <div className="container mx-auto px-5 py-3 w-50 rounded-4">
                <div>
                    <form className="d-flex justify-content-around">
                    <textarea className="rounded-end rounded-4 form-control" id="jokeTextArea" rows="5"></textarea>
                    <button type="submit" className="btn btn-dark rounded-start rounded-4">Post</button>
                    </form>
                </div>
                {
                    jokes.map(joke => (
                        <div className="border rounded-4 hover-shadow my-3 p-4 bg-white">
                            <div className="d-flex">
                                <img src="https://sun9-76.userapi.com/impg/iv0Evj8r25RjdZmpg8LzSlcQ8IXMFVsiORN0vw/Qy-5UzwZrnM.jpg?size=1080x817&quality=96&sign=df64f607449fafce071adceede4339d2&type=album" width="70px" height="70px" alt="Avatar" class="rounded-circle"/>
                                <div className="mx-3">
                                    <h3>
                                        {joke.author}
                                    </h3>
                                    <p>
                                        {joke.creationTime}
                                    </p>
                                </div>
                            </div>
                            <p style={{ whiteSpace: "pre-line" }}>{joke.text}</p>
                            <div className="d-flex justify-content-between">
                                <LikeButton likes={joke.likes} />
                                <button className="btn">
                                    <img width="20px" src="https://cdn-icons-png.flaticon.com/512/2990/2990295.png" alt="" />
                                </button>
                            </div>
                        </div>
                    ))
                }
            </div>
        </div>
    );
}

export default App;

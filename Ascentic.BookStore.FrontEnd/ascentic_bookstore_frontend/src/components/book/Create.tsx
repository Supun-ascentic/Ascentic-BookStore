import * as React from 'react';
import axios from 'axios';
import { RouteComponentProps, withRouter } from 'react-router-dom';

export interface IValues {
    title: string,
    categoryId:Number,
    price: Number,
    description: string,
}
export interface IFormState {
    [key: string]: any;
    values: IValues[];
    submitSuccess: boolean;
    loading: boolean;
}

class Create extends React.Component<RouteComponentProps, IFormState> {
    constructor(props: RouteComponentProps) {
        super(props);
        this.state = {
            title: '',
            categoryId: 0,
            price: 0,
            description: '',
            values: [],
            loading: false,
            submitSuccess: false,
        }
    }

    private processFormSubmission = (e: React.FormEvent<HTMLFormElement>): void => {
        e.preventDefault();
        this.setState({ loading: true });
        const formData = {
            title: this.state.title,
            categoryId: this.state.categoryId,
            price: this.state.price,
            description: this.state.description,
        }
        this.setState({ submitSuccess: true, values: [...this.state.values, formData], loading: false });

        let config = {
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
                'Access-Control-Allow-Origin': '*',
            }
          }

        axios.post(`https://localhost:44359/api/Book`, formData,config).then(data => [
            setTimeout(() => {
                this.props.history.push('/');
            }, 1500)
        ]);
    }

    private handleInputChanges = (e: React.FormEvent<HTMLInputElement>) => {
        e.preventDefault();
        this.setState({
            [e.currentTarget.name]: e.currentTarget.value,
    })
}


public render() {
    const { submitSuccess, loading } = this.state;
    return (
        <div>
            <div className={"col-md-12 form-wrapper"}>
                <h2> Create Post </h2>
                {!submitSuccess && (
                    <div className="alert alert-info" role="alert">
                        Fill the form below to create a new post
                </div>
                )}
                {submitSuccess && (
                    <div className="alert alert-info" role="alert">
                        The form was successfully submitted!
                        </div>
                )}
                <form id={"create-post-form"} onSubmit={this.processFormSubmission} noValidate={true}>
                    <div className="form-group col-md-12">
                        <label htmlFor="title"> Title </label>
                        <input type="text" id="title" onChange={(e) => this.handleInputChanges(e)} name="title" className="form-control" placeholder="Enter book title" />
                    </div>
                    <div className="form-group col-md-12">
                        <label htmlFor="categoryId"> category Id </label>
                        <input type="text" id="categoryId" onChange={(e) => this.handleInputChanges(e)} name="categoryId" className="form-control" placeholder="Enter book category Id" />
                    </div>
                    <div className="form-group col-md-12">
                        <label htmlFor="price"> Price </label>
                        <input type="text" id="price" onChange={(e) => this.handleInputChanges(e)} name="price" className="form-control" placeholder="Enter book price" />
                    </div>
                    <div className="form-group col-md-12">
                        <label htmlFor="description"> Description </label>
                        <input type="text" id="description" onChange={(e) => this.handleInputChanges(e)} name="description" className="form-control" placeholder="Enter book description" />
                    </div>
                    <div className="form-group col-md-4 pull-right">
                        <button className="btn btn-success" type="submit">
                            Add Book
                        </button>
                        {loading &&
                            <span className="fa fa-circle-o-notch fa-spin" />
                        }
                    </div>
                </form>
            </div>
        </div>
    )
}
}
export default withRouter(Create)